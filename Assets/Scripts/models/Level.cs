using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class Level {
    public int index;
    public List<BombInfo> bombs;
    public string tutorialContent;
    public string tutorialImage;
    public string tutorialTitle = "";

    public Level()
    {

    }

    public Level(int index,List<BombInfo> bombs, string tutorialContent, string tutorialImage)
    {
        this.index = index;
        this.bombs = bombs;
        this.tutorialContent = tutorialContent;
        this.tutorialImage = tutorialImage;
    }

    public string toString()
    {
        return "Level: " + index + ", Tutorial: " + tutorialContent + "==" + tutorialImage + ", Bombs: " + bombs.Count; 
    }
}
