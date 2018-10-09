using System;

[Serializable]
public class PlayerData
{
    public int [] levels;
    public bool [] unlocked;

    // for show ads
    public int totalMatch;

    public PlayerData()
    {
    }
}
