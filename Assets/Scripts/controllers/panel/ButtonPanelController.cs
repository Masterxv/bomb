using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPanelController : BasePanelController {

    public Text clickCounterText;

    public void MainMenuBtnClick()
    {
        SceneManager.LoadScene((int)SceneEnum.MenuScene);
    }

    public void LevelSelectBtnClick()
    {
        SceneManager.LoadScene((int)SceneEnum.LevelSelectScene);
    }

    public void ReplayBtnClick(bool withBackup = false)
    {
        ControllerUtil.coreController.Refresh(withBackup);
    }

    public void updateClickCounter(Level level)
    {
        clickCounterText.text = (level.numberOfClick - ControllerUtil.coreController.clickedNumber).ToString();
    }

}
