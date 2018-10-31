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
        eslapedTime = 0;
        maxTimer = -1;
        isAnimating = false;
        clickedNumber = 0;

        resultPanel.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        resultPanel.SetActive(false);

        level = LevelUtil.getCurrentLevel();
        numberOfClick = level.numberOfClick;
        extraBombs = level.extraBombs;

        RemoveAllBullets();
        RemoveAllCurrentBombs();
        RemoveAllCurrentWalls();

        InitBombs();
        InitWalls();
        InitTutorial();
        InitButtonPanel();
    }
}
