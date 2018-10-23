using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;

public abstract class CoreController : MonoBehaviour
{
    // Level
    public Level level;

    // Panel
    public GameObject resultPanel;
    public GameObject tutorialPanel;
    public GameObject helperPanel;
    public GameObject messageDialog;

    // Utilities
    public int clickedNumber;
    public int numberOfClick;
    public bool isAnimating; // Check if have any doing animation
    public IEnumerator coroutine; // coroutine for end game logic
    public ExtraBombInfo[] extraBombs;
    protected bool ended = false;

    #region Init and Update methods
    protected void InitBombs()
    {
        // Init all bombs in level
        for (int i = 0; i < level.bombs.Count; i++)
        {
            BombInfo bombInfo = level.bombs[i];
            BombManager.Instance.CreateBomb(bombInfo);
        }
    }

    protected void InitWalls()
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

    protected void InitTutorial()
    {
        tutorialPanel.GetComponent<TutorialPanelController>().init(level);
    }

    protected void InitHelperPanel()
    {
        helperPanel.GetComponent<HelperPanelController>().init(level);
    }

    public void UpdateClickedNumber()
    {
        clickedNumber++;
        helperPanel.GetComponent<HelperPanelController>().updateHandCount(level);
    }

    #endregion

    #region mono behavior methods

    void Awake()
    {
        PlayerDataUtil.SavePlayerDataFirstTime(); // TODO: remove in production
        PlayerDataUtil.LoadPlayerData(); // TODO: remove in production
    }

    // Use this for initialization
    void Start()
    {
        ControllerUtil.init();
        level = LevelUtil.LoadLevelData(PlayerDataUtil.playerData.unlockedLevelIndex);
        Refresh();
    }

    public abstract void Refresh(bool withBackup = false);

    // Update is called once per frame
    protected void Update()
    {
        if (resultPanel.activeInHierarchy)
        {
            return;
        }

        int numberOfBullet = findGameObjectsWithTag("bullet").Length;
        if(isAnimating || numberOfBullet > 0) { return; }
        int numberOfBomb = findGameObjectsWithTag("bomb").Length;
        if (clickedNumber < numberOfBullet && numberOfBomb > 0) { return; }

        // end game logic
        coroutine = EndGameLogic(1.0f);
        StartCoroutine(coroutine);
    }

    #endregion

    public void fillDialogInfo(string title, string content)
    {
        messageDialog.GetComponent<MessageDialogController>().fillDialogInfo(title, content);
    }
    public void showMessageDialog(bool isFillDialogInfo = false, string title = "", string content = "")
    {
        if (isFillDialogInfo)
        {
            fillDialogInfo(title, content);
        }
        messageDialog.SetActive(true);
    }

    public void hideMessageDialog()
    {
        messageDialog.SetActive(false);
    }


    public void RemoveAllBullets()
    {
        GameObject[] bullets = findGameObjectsWithTag("bullet");
        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i]);
        }
    }

    public void RemoveAllCurrentBombs()
    {
        GameObject[] bombs = findGameObjectsWithTag("bomb");
        for (int i = 0; i < bombs.Length; i++)
        {
            Destroy(bombs[i]);
        }
    }

    public void RemoveAllCurrentWalls()
    {
        GameObject[] walls = findGameObjectsWithTag("wall");
        for (int i = 0; i < walls.Length; i++)
        {
            Destroy(walls[i]);
        }
    }

    // All logic when end a game level
    public IEnumerator EndGameLogic(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (!ended && clickedNumber >= numberOfClick && !isAnimating && findGameObjectsWithTag("bullet").Length <= 0)
        {
            ended = true;
            RemoveAllCurrentBombs();
            RemoveAllCurrentWalls();
            StopCoroutine(coroutine);
            // End this level, show the result panel
            resultPanel.SetActive(true);
            resultPanel.transform.DOScale(new Vector3(0.5f, 0.5f, 0), 1); // Animate to show result panel

            // Unlocked level if need
            int remainBombs = findGameObjectsWithTag("bomb").Length;
            bool isNextLevelUnlocked = false;
            if (level.index < Constants.TOTAL_LEVEL - 1)
            {
                isNextLevelUnlocked = level.index + 1 <= PlayerDataUtil.playerData.unlockedLevelIndex;
                if (remainBombs <= 0)
                {
                    if (!isNextLevelUnlocked)
                    {
                        // Unlock next level if it was locked
                        PlayerDataUtil.playerData.unlockedLevelIndex += 1;
                        isNextLevelUnlocked = true;
                    }
                }
            }

            // Fill result panel
            ResultPanelController resultsPanelController = resultPanel.GetComponent<ResultPanelController>();
            resultsPanelController.fillData(remainBombs, isNextLevelUnlocked);
            PlayerDataUtil.playerData.totalMatch++;
            PlayerDataUtil.SavePlayerData();

            // Show ads depend on total match of player
            if (PlayerDataUtil.playerData.totalMatch % Constants.MATCH_COUNT_EACH_POPUP_ADS == 0)
            {
                // TODO: Display popup ads
                Debug.LogError("Display ads");
            }
        }
    }


    #region Utilities methods
    protected GameObject[] findGameObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    #endregion
}