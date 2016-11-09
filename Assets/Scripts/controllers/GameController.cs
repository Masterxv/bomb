using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject normalBomb;
    public GameObject shooterBomb;
    public GameObject targetBomb;
    public GameObject waveBomb;
    public GameObject acidBomb;

    public GameObject normalWall;
    public GameObject contraryWall;

    public GameObject resultPanel;

    public Sprite starSprite;

    public string levelIndex;
    public int clickedNumber;
    public int numberOfClick;
    public Text handCount;

    public bool isAnimating;

    static GameController _instance;
    public static GameController instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    void MainSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 2)
        {
            clickedNumber = 0;
        }
    }

    void InitBombs(Level level)
    {
        // Init all bombs in level
        for (int i = 0; i < level.bombs.Count; i++)
        {
            BombInfo bombInfo = level.bombs[i];
            GameObject bomb = null;
            switch (bombInfo.type)
            {
                case Constants.BombTypes.normal:
                    bomb = Instantiate(normalBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.BombTypes.shooter:
                    bomb = Instantiate(shooterBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.BombTypes.target:
                    bomb = Instantiate(targetBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.BombTypes.wave:
                    bomb = Instantiate(waveBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.BombTypes.acid:
                    bomb = Instantiate(acidBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
            }
            if (bomb == null)
            {
                bomb = Instantiate(normalBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
            }
            bomb.GetComponent<Explode>().setBombData(bombInfo);
            if (bombInfo.movement == null)
            {
                bomb.GetComponent<BombMovement>().enabled = false;
            }
            else
            {
                bomb.GetComponent<BombMovement>().SetMovementData(bombInfo.movement);
            }
        }
    }

    void InitWalls(Level level)
    {
        if(level.walls == null)
        {
            return;
        }
        for (var i = 0; i < level.walls.Count; i++)
        {
            WallInfo wallInfo = level.walls[i];
            GameObject wall = null;
            switch (wallInfo.type)
            {
                case Constants.WallTypes.normal:
                    wall = Instantiate(normalWall, wallInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.WallTypes.contrary:
                    wall = Instantiate(contraryWall, wallInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
            }
            if (wall == null)
            {
                wall = Instantiate(normalWall, wallInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
            }
            wall.GetComponent<Wall>().setWallData(wallInfo);
        }
    }

    void InitTutorial(Level level)
    {
        // Init tutorials
        if (level.tutorialContent == "")
        {
            GameObject.Find("Tutorial").SetActive(false);
        }
        else
        {
            GameObject.Find("Tutorial").GetComponentInChildren<Text>().text = level.tutorialContent;
            GameObject.Find("Tutorial").GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/tutorials/" + level.tutorialImage);
        }
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
        handCount.text = numberOfClick + "";

        if(DesignLevelController.active)
        {
            return;
        }
        Level level = LevelUtil.getCurrentLevel();

        InitBombs(level);
        InitWalls(level);
        InitTutorial(level);
        UpdateGold();
    }

    public void UpdateGold()
    {
        GameObject.Find("CoinMeterCount").GetComponent<TextMesh>().text = PlayerDataUtil.playerData.gold.ToString();
    }

    public void UpdateClickedNumber()
    {
        clickedNumber++;
        handCount.text = (LevelUtil.getCurrentLevel().numberOfClick - clickedNumber) + "";
    }

    // Update is called once per frame
    void Update()
    {
        if (clickedNumber >= numberOfClick && !isAnimating && GameObject.FindGameObjectsWithTag("bullet").Length <= 0)
        {
            if(resultPanel.activeInHierarchy)
            {
                return;
            }
            // End this level, show the result panel
            resultPanel.SetActive(true);
            resultPanel.transform.DOScale(new Vector3(0.5f, 0.5f, 0), 1); ; // Animate to show result panel
            int remainBombs = GameObject.FindGameObjectsWithTag("bomb").Length;
            GameObject.Find("RemainBombValue").GetComponent<Text>().text = remainBombs + "";
            int stars = GetStars(remainBombs);
            switch (stars)
            {
                case 1:
                    GameObject.Find("Star1").GetComponent<Image>().sprite = starSprite;
                    break;
                case 2:
                    GameObject.Find("Star1").GetComponent<Image>().sprite = starSprite;
                    GameObject.Find("Star2").GetComponent<Image>().sprite = starSprite;
                    break;
                case 3:
                    GameObject.Find("Star1").GetComponent<Image>().sprite = starSprite;
                    GameObject.Find("Star2").GetComponent<Image>().sprite = starSprite;
                    GameObject.Find("Star3").GetComponent<Image>().sprite = starSprite;
                    break;
            }
            if(stars > 0)
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
            PlayerDataUtil.SavePlayerData();
        }
    }

    public static int GetStars(int remainBombs)
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
