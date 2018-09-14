﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanelController : MonoBehaviour
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
            content.text = level.tutorialContent.descriptions;
            image.sprite = Resources.Load<Sprite>("Sprites/tutorials/" + level.tutorialContent.image);
        }
    }
}
