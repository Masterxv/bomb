using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanelController : MonoBehaviour
{
    public Image image;
    public Text content;

    public void init(Level level)
    {
        if (level.tutorialContent == string.Empty)
        {
            gameObject.SetActive(false);
        }
        else
        {
            content.text = level.tutorialContent;
            image.sprite = Resources.Load<Sprite>("Sprites/tutorials/" + level.tutorialImage);
        }
    }
}

