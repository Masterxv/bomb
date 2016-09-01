﻿using System;

[Serializable]
public class PlayerData
{
    public int [] levels;
    public int [] stars;

    public int normalLevel;
    public int shooterLevel;
    public int waveLevel;
    public int targetLevel;
    public int goldLevel;

    public int normalExtra;
    public int shooterExtra;
    public int waveExtra;
    public int targetExtra;

    public int powerUpMoreClick;
    public int powerUpMoreBomb;

    public int earnedStars;
    public int spentStars;
    public int starResetedTime;

    public int gold;

    public PlayerData()
    {
    }
}
