﻿using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;

public abstract class CoreController: MonoBehaviour
{
    // Level
    public Level level;

    // Panel
    public GameObject resultPanel;
    public GameObject coinMeter;
    public GameObject tutorialPanel;
    public GameObject helperPanel;
    public GameObject messageDialog;

    // Utilities
    public Sprite starSprite;
    public int clickedNumber;
    public int numberOfClick;
    public bool isAnimating; // Check if have any doing animation
    public IEnumerator coroutine; // coroutine for end game logic
    public ExtraBombInfo[] extraBombs;

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

    public void UpdateGold()
    {
        coinMeter.GetComponentInChildren<Text>().text = PlayerDataUtil.playerData.gold.ToString();
    }

    #endregion

    #region mono behavior methods

    void Awake()
    {
        //PlayerDataUtil.SavePlayerDataFirstTime(); // TODO: remove in production
        PlayerDataUtil.LoadPlayerData(); // TODO: remove in production
    }

    // Use this for initialization
    void Start()
    {
        ControllerUtil.init();
        Refresh();
    }

    public abstract void Refresh();

    // Update is called once per frame
    void Update()
    {
        if (clickedNumber >= numberOfClick && !isAnimating && findGameObjectsWithTag("bullet").Length <= 0)
        {
            if (resultPanel.activeInHierarchy)
            {
                return;
            }
            coroutine = EndGameLogic(1.0f);
            StartCoroutine(coroutine);
        }
    }

    #endregion

    public void fillDialogInfo(string title, string content)
    {
        messageDialog.GetComponent<MessageDialogController>().fillDialogInfo(title, content);
    }
    public void showMessageDialog(bool isFillDialogInfo=false, string title="", string content="")
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

    // All logic when end a game level
    public IEnumerator EndGameLogic(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (clickedNumber >= numberOfClick && !isAnimating && findGameObjectsWithTag("bullet").Length <= 0)
        {
            StopCoroutine(coroutine);
            // End this level, show the result panel
            resultPanel.SetActive(true);
            resultPanel.transform.DOScale(new Vector3(0.5f, 0.5f, 0), 1); ; // Animate to show result panel

            // Calculate star
            int remainBombs = findGameObjectsWithTag("bomb").Length;
            ResultPanelController resultsPanelController = resultPanel.GetComponent<ResultPanelController>();
            resultsPanelController.remainBomb.text = remainBombs.ToString();
            int stars = LevelUtil.GetStars(remainBombs);
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


    #region Utilities methods
    GameObject[] findGameObjectsWithTag(string tag)
    {
        return GameObject.FindGameObjectsWithTag(tag);
    }

    #endregion
}