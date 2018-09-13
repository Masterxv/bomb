using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class TutorialContent
{
    public string title;
    public string descriptions;
    public string image;
    
    public TutorialContent()
    {
    }

    public TutorialContent(string title, string descriptions, string image)
    {
        this.title = title;
        this.descriptions = descriptions;
        this.image = image;
    }
}