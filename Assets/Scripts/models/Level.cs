using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class Level
{
    public int index;
    public List<BombInfo> bombs;
    public List<WallInfo> walls;
    public int numberOfClick;
    public TutorialContent tutorialContent;
    public ExtraBombInfo[] extraBombs;

    public Level()
    {

    }

    public Level(int index, int numberOfClick, TutorialContent tutorialContent, List<BombInfo> bombs, List<WallInfo> walls, ExtraBombInfo[] extraBombs)
    {
        this.index = index;
        this.numberOfClick = numberOfClick;
        this.tutorialContent = tutorialContent;
        this.bombs = bombs;
        this.walls = walls;
        this.extraBombs = extraBombs;
    }
}
