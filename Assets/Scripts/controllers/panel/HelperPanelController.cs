using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperPanelController : MonoBehaviour
{
    const int EXTRA_BOMB_MAX_INDEX = 2;
    public Text handCount;
    public GameObject[] extraBombGameObjects; 

    public void init(Level level)
    {
        refresh(level);
    }

    public void refresh(Level level)
    {
        updateHandCount(level);
        updateExtraboms(level);
    }

    public void updateExtraboms(Level level)
    {
        ExtraBombInfo[] extraBombs = level.extraBombs;
        for(var i=0; i<extraBombs.Length; i++)
        {
            if (i > EXTRA_BOMB_MAX_INDEX)
            {
                return;
            }
            updateAnExtraBombItem(extraBombGameObjects[i], extraBombs[i]);
        }
    }

    public void updateAnExtraBombItemByIndex(int index, Level level)
    {
        if (index > EXTRA_BOMB_MAX_INDEX)
        {
            return;
        }
        updateAnExtraBombItem(extraBombGameObjects[index], level.extraBombs[index]);
    }

    public void updateAnExtraBombItem(GameObject extraBombGameObject, ExtraBombInfo extraBombInfo)
    {
        ExtraBomb extraBomb = extraBombGameObject.GetComponent<ExtraBomb>();
        extraBomb.image.sprite = SpriteManager.Instance.spriteAtlas.GetSprite("bomb_" + extraBombInfo.bombType);
        extraBomb.count.text = extraBombInfo.count + String.Empty;
        extraBombGameObject.SetActive(true);
    }

    public void updateHandCount(Level level)
    {
        handCount.text = (level.numberOfClick - ControllerUtil.coreController.clickedNumber).ToString();
    }

    public void extraBombItemOnClick()
    {
        // event when click an extra bomb item
    }

    public void extraBombItemOnPlace()
    {
        // event when place extra bomb in screen
    }
}

