using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

[Serializable]
public class Level
{
    public int index;
    public int numberOfClick;
    public TutorialContent tutorialContent;

    public List<BombInfo> bombs;
    public List<WallInfo> walls;
    public ExtraBombInfo[] extraBombs;

    // bombs level
    public int normalLevel;
    public int shooterLevel;
    public int waveLevel;
    public int targetLevel;
    public int acidLevel;

    public Level()
    {

    }

    public Level(int index, int numberOfClick, TutorialContent tutorialContent, List<BombInfo> bombs, List<WallInfo> walls, ExtraBombInfo[] extraBombs, int normalLevel=1, int shooterLevel=1, 
        int waveLevel=1, int targetLevel=1, int acidLevel=1)
    {
        this.index = index;
        this.numberOfClick = numberOfClick;
        this.tutorialContent = tutorialContent;
        this.bombs = bombs;
        this.walls = walls;
        this.extraBombs = extraBombs;

        this.normalLevel = normalLevel;
        this.shooterLevel = shooterLevel;
        this.waveLevel = waveLevel;
        this.targetLevel = targetLevel;
        this.acidLevel = acidLevel;
    }
}
