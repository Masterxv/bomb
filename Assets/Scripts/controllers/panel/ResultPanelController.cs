using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanelController : MonoBehaviour
{
    public Image icon;
    public Sprite starFilled;
    public Sprite starEmpty;
    public Text message;
    public Button nextLevelBtn;
    public Button replayBtn;

    private bool nextLevelUnlocked;

    public void fillData(int remainBombs, bool nextLevelUnlocked)
    {
        if (remainBombs <= 0)
        {
            icon.sprite = starFilled;
            message.text = "All bomb cleared!!!";
        }
        else
        {
            icon.sprite = starEmpty;
            message.text = "Bomb remain: " + remainBombs;
        }

        this.nextLevelUnlocked = nextLevelUnlocked;
        if(nextLevelUnlocked)
        {
            nextLevelBtn.GetComponentInParent<Image>().color = Color.white;
        } else
        {
            nextLevelBtn.GetComponentInParent<Image>().color = Color.red;
        }
    }

    public void replay()
    {
        ControllerUtil.coreController.Refresh();
    }

    public void nextLevel()
    {
        if(!nextLevelUnlocked)
        {
            return;
        }
        // Load level data
        Level level = LevelUtil.LoadLevelData(LevelUtil.getCurrentLevel().index + 1);
        // Set seleted level data to main scene
        LevelUtil.setCurrentLevel(level);
        ControllerUtil.coreController.Refresh();
    }
}

