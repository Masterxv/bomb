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

    public Level()
    {

    }

    public Level(int index, int numberOfClick, TutorialContent tutorialContent, List<BombInfo> bombs, List<WallInfo> walls)
    {
        this.index = index;
        this.numberOfClick = numberOfClick;
        this.bombs = bombs;
        this.walls = walls;
        this.tutorialContent = tutorialContent;
    }
}
