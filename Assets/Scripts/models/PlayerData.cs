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

    public int normalExtra;
    public int shooterExtra;
    public int waveExtra;
    public int targetExtra;

    public PlayerData()
    {
        normalLevel = 1;
        shooterLevel = 1;
        waveLevel = 1;
        targetLevel = 1;

        normalExtra = 0;
        shooterExtra = 0;
        waveExtra = 0;
        targetExtra = 0;
    }
}
