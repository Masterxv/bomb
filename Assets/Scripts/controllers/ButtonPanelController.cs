using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPanelController : MonoBehaviour {

    public void MainMenuBtnClick()
    {
        SceneManager.LoadScene(0);
    }

    public void LevelSelectBtnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void UpgradeBtnClick()
    {
        SceneManager.LoadScene(3);
    }

    public void ShopBtnClick()
    {
        SceneManager.LoadScene(4);
    }

    public void AchievementBtnClick()
    {
        SceneManager.LoadScene(5);
    }

    public void ReplayBtnClick()
    {
        LevelController.GoToLevel(LevelUtil.getCurrentLevel().index);
    }

    public void NextLevelBtnclick()
    {
        if (LevelUtil.getCurrentLevel().index >= Constants.TOTAL_LEVEL)
        {
            SceneManager.LoadScene(1);
        } else
        {
            GameController.instance.resultPanel.SetActive(false);
            LevelController.GoToLevel(LevelUtil.getCurrentLevel().index + 1);
        }
    }

    public void GenerateBtnClick()
    {
        SceneManager.LoadScene(4);
    }

    public void RateUsBtnClick()
    {
        Debug.Log("Rate us click");
    }
}
