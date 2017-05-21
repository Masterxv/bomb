using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void RateUsBtnClick()
    {
        Application.OpenURL("http://unity3d.com/");
    }

    public void MoreGameBtnClick()
    {
        Application.OpenURL("http://google.com/");
    }

    public void PlayBtnClick()
    {
        SceneManager.LoadScene(2);
    }
}

