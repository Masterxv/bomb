using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperPanelController : MonoBehaviour
{
    public Text handCount;
    public Text moreBombCount;
    public Text moreClickCount;

    public void init()
    {
        refresh();
    }

    private void refresh()
    {
        handCount.text = (GameController.Instance.numberOfClick - GameController.Instance.clickedNumber).ToString();
        moreBombCount.text = PlayerDataUtil.playerData.powerUpMoreBomb.ToString();
        moreClickCount.text = PlayerDataUtil.playerData.powerUpMoreClick.ToString();
    }

    public void MoreBombBtnClick()
    {
        if(PlayerDataUtil.playerData.powerUpMoreBomb > 0)
        {
            GameController.Instance.AddMoreBomb();
            PlayerDataUtil.playerData.powerUpMoreBomb--;
            refresh();
        }
    }

    public void MoreClickBtnClick()
    {
        if(PlayerDataUtil.playerData.powerUpMoreClick > 0)
        {
            GameController.Instance.numberOfClick++;
            PlayerDataUtil.playerData.powerUpMoreClick--;
            refresh();
        }
    }
}

