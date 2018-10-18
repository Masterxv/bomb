using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPanelController : MonoBehaviour {

    public void MainMenuBtnClick()
    {
        SceneManager.LoadScene((int)SceneEnum.MenuScene);
    }

    public void LevelSelectBtnClick()
    {
        SceneManager.LoadScene((int)SceneEnum.LevelSelectScene);
    }

    public void ReplayBtnClick()
    {
        ControllerUtil.coreController.Refresh();
    }
}
