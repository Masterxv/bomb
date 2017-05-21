using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameController : MySingleton<GameController>
{
    // Level
    Level level;

    // Panel
    public GameObject resultPanel;
    public GameObject coinMeter;
    public GameObject tutorial;
    public GameObject helperPanel;

    // Utilities
    public Sprite starSprite;
    private string levelIndex;
    public int clickedNumber;
    public int numberOfClick;
    public bool isAnimating; // Check if have any doing animation
    public IEnumerator coroutine; // coroutine for end game logic

    void MainSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            clickedNumber = 0;
        }
    }

    void InitBombs()
    {
        // Init all bombs in level
        for (int i = 0; i < level.bombs.Count; i++)
        {
            BombInfo bombInfo = level.bombs[i];
            BombManager.Instance.CreateBomb(bombInfo);
        }
    }

    void InitWalls()
    {
        if (level.walls == null)
        {
            return;
        }
        for (var i = 0; i < level.walls.Count; i++)
        {
            WallInfo wallInfo = level.walls[i];
            WallManager.Instance.CreateWall(wallInfo);
        }
    }

    void InitTutorial()
    {
        tutorial.GetComponent<TutorialPanelController>().init(level);
    }

    void InitPowerUp()
    {
        helperPanel.GetComponent<HelperPanelController>().init();
    }

    // Use this for initialization
    void Start()
    {
        SceneManager.sceneLoaded += MainSceneLoaded;
        PlayerDataUtil.SavePlayerDataFirstTime(); // TODO: remove in production
        PlayerDataUtil.LoadPlayerData(); // TODO: remove in production

        resultPanel.SetActive(false);
        isAnimating = false;

        // Init number of click stuff
        clickedNumber = 0;
        numberOfClick = LevelUtil.getCurrentLevel().numberOfClick;

        if (DesignLevelController.active)
        {
            return;
        }
        level = LevelUtil.getCurrentLevel();

        InitBombs();
        InitWalls();
        InitTutorial();
        InitPowerUp();
        UpdateGold();
        PlayerDataUtil.playerData.totalMatch++;
    }

    public void UpdateGold()
    {
        coinMeter.GetComponentInChildren<TextMesh>().text = PlayerDataUtil.playerData.gold.ToString();
    }

    public void UpdateClickedNumber()
    {
        clickedNumber++;
        helperPanel.GetComponent<HelperPanelController>().handCount.text = (numberOfClick - clickedNumber).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (clickedNumber >= numberOfClick && !isAnimating && GameObject.FindGameObjectsWithTag("bullet").Length <= 0)
        {
            if (resultPanel.activeInHierarchy)
            {
                return;
            }
            coroutine = EndGameLogic(1.0f);
            StartCoroutine(coroutine);
        }
    }

    // All logic when end a game level
    public IEnumerator EndGameLogic(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (clickedNumber >= numberOfClick && !isAnimating && GameObject.FindGameObjectsWithTag("bullet").Length <= 0)
        {
            StopCoroutine(coroutine);
            // End this level, show the result panel
            resultPanel.SetActive(true);
            resultPanel.transform.DOScale(new Vector3(0.5f, 0.5f, 0), 1); ; // Animate to show result panel

            // Calculate star
            int remainBombs = GameObject.FindGameObjectsWithTag("bomb").Length;
            ResultPanelController resultsPanelController = resultPanel.GetComponent<ResultPanelController>();
            resultsPanelController.remainBomb.text = remainBombs.ToString();
            int stars = GetStars(remainBombs);
            switch (stars)
            {
                case 1:
                    resultsPanelController.star1.sprite = starSprite;
                    break;
                case 2:
                    resultsPanelController.star1.sprite = starSprite;
                    resultsPanelController.star2.sprite = starSprite;
                    break;
                case 3:
                    resultsPanelController.star1.sprite = starSprite;
                    resultsPanelController.star2.sprite = starSprite;
                    resultsPanelController.star3.sprite = starSprite;
                    break;
            }
            if (stars > 0)
            {
                int currentLevelStars = PlayerDataUtil.playerData.stars[LevelUtil.getCurrentLevel().index - 1];
                if (stars > currentLevelStars) // Update current level star if this time stars is larger than last time stars.
                {
                    PlayerDataUtil.playerData.stars[LevelUtil.getCurrentLevel().index - 1] = stars;
                    PlayerDataUtil.playerData.earnedStars += (stars - currentLevelStars); // Update earned stars
                }
                int nextLevelStars = PlayerDataUtil.playerData.stars[LevelUtil.getCurrentLevel().index];
                if (nextLevelStars == -1) // Unlock next level if it was locked
                {
                    PlayerDataUtil.playerData.stars[LevelUtil.getCurrentLevel().index] = 0;
                }
            }

            // Add exploded bomb
            int explodedBombs = LevelUtil.getCurrentLevel().bombs.Count - remainBombs;
            PlayerDataUtil.playerData.totalBombExploded += explodedBombs;

            // Calculate best combo
            if (clickedNumber == 1 && explodedBombs > PlayerDataUtil.playerData.bestCombo)
            {
                PlayerDataUtil.playerData.bestCombo = explodedBombs;
            }

            PlayerDataUtil.SavePlayerData();

            // Show ads depend on total match of player
            if (PlayerDataUtil.playerData.totalMatch % Constants.MATCH_COUNT_EACH_POPUP_ADS == 0)
            {
                // TODO: Display popup ads

            }
        }
    }

    public void AddMoreBomb()
    {
        // Init all bombs in level
        for (int i = 0; i < level.bombs.Count; i++)
        {
            BombInfo bombInfo = new BombInfo(level.bombs[i]);
            bombInfo.movement = null;
            bombInfo.initPosition.x = Random.Range(-90, 90);
            bombInfo.initPosition.y = Random.Range(-40, 40);
            bombInfo.initAngle = Random.Range(0, 360);

            BombManager.Instance.CreateBomb(bombInfo);
        }
    }

    public int GetStars(int remainBombs)
    {
        if (remainBombs <= Constants.BOMB_REMAIN_3_STAR_THRESHOLD)
        {
            return 3;
        }
        else if (remainBombs <= Constants.BOMB_REMAIN_2_STAR_THRESHOLD)
        {
            return 2;
        }
        else if (remainBombs <= Constants.BOMB_REMAIN_1_STAR_THRESHOLD)
        {
            return 1;
        }
        return 0;
    }
}
