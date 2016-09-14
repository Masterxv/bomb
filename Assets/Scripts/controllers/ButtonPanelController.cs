using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPanelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

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

    public void PauseBtnClick()
    {
        Debug.Log("PAUSE BTN CLICK");
    }

    public void ReplayBtnClick()
    {
        LevelController.GoToLevel(LevelUtil.getCurrentLevel().index);
    }

    public void GenerateBtnClick()
    {
        SceneManager.LoadScene(4);
    }

    public void FacebookBtnClick()
    {
        Debug.Log("Facebook BTN CLICK");
    }

    public void RateUsBtnClick()
    {
        Debug.Log("Rate us click");
    }
}
