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
        Debug.LogError("Refresh in Game controller");
        SceneManager.sceneLoaded += MainSceneLoaded;
        PlayerDataUtil.SavePlayerDataFirstTime(); // TODO: remove in production
        PlayerDataUtil.LoadPlayerData(); // TODO: remove in production

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

        InitBombs();
        InitWalls();
        InitTutorial();
        InitHelperPanel();
        UpdateGold();
        PlayerDataUtil.playerData.totalMatch++;
    }
}
