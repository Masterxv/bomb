using System;

[Serializable]
public class PlayerData
{
    public int [] levels;
    public int [] stars;

    public int normalLevel;
    public int shooterLevel;
    public int waveLevel;
    public int targetLevel;
    public int acidLevel;
    public int goldLevel;

    public int powerUpMoreClick;
    public int powerUpMoreBomb;

    public int spentStars;
    public int starResetedTime;

    public int gold;

    // for achievement
    public int totalEarnedGold;
    public int totalBombExploded;
    public int totalPowerupPuchased;
    public int bestCombo;
    public int totalUpgrade;
    public int earnedStars;

    // for show ads
    public int totalMatch;

    public PlayerData()
    {
    }
}
