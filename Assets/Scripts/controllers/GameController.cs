using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameController : CoreController
{
    void MainSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 2)
        {
            clickedNumber = 0;
        }
    }

    public override void Refresh(bool withBackup)
    {
        Debug.Log("Refresh in Game controller");
        SceneManager.sceneLoaded += MainSceneLoaded;

        ended = false;
        resultPanel.SetActive(false);
        isAnimating = false;

        // Init number of click stuff
        clickedNumber = 0;
        level = LevelUtil.getCurrentLevel();
        numberOfClick = level.numberOfClick;
        extraBombs = level.extraBombs;

        if (DesignLevelController.active)
        {
            return;
        }

        RemoveAllBullets();
        RemoveAllCurrentBombs();
        RemoveAllCurrentWalls();

        InitBombs();
        InitWalls();
        InitTutorial();
        InitButtonPanel();
    }
}
