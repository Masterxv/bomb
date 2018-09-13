using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperPanelController : MonoBehaviour
{
    public Text handCount;

    public void init()
    {
        refresh();
    }

    public void refresh()
    {
        updateHandCount();
    }

    public void updateHandCount()
    {
        handCount.text = (GameController.Instance.numberOfClick - GameController.Instance.clickedNumber).ToString();
    }
}

