using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanelController : BasePanelController
{
    public Image image;
    public Text content;

    public void init(Level level)
    {
        if (level.tutorialContent.descriptions == string.Empty)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            content.text = level.tutorialContent.descriptions;
            image.sprite = SpriteManager.Instance.spriteAtlas.GetSprite(level.tutorialContent.image);
        }
    }
}

