using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerDataUtil
{

    public static PlayerData playerData;

    public static void SavePlayerData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite(Application.persistentDataPath + "/playerInfo.dat");
        bf.Serialize(file, playerData);
        file.Close();
    }

    public static void SavePlayerDataFirstTime()
    {
        playerData = new PlayerData();
        playerData.levels = new int[Constants.TOTAL_LEVEL];
        playerData.stars = new int[Constants.TOTAL_LEVEL];
        for (int i = 0; i < Constants.TOTAL_LEVEL; i++)
        {
            playerData.levels[i] = i;
            playerData.stars[i] = -1;
        }
        playerData.stars[0] = 0;
        playerData.stars[1] = 2;
        playerData.stars[2] = 3;
        playerData.stars[3] = 3;
        playerData.stars[4] = 3;
        playerData.stars[5] = 3;
        playerData.stars[6] = 3;
        playerData.stars[7] = 3;
        playerData.stars[8] = 0;

        playerData.earnedStars = 0;
        playerData.spentStars = 0;
        playerData.starResetedTime = 0;

        playerData.gold = 100000;

        // Achievement
        playerData.totalEarnedGold = 0;
        playerData.totalBombExploded = 0;
        playerData.totalPowerupPuchased = 0;
        playerData.totalUpgrade = 0;
        playerData.bestCombo = 0;

        // Powerup
        playerData.powerUpMoreBomb = 10;
        playerData.powerUpMoreClick = 5;

        // Count match to show ads
        playerData.totalMatch = 0;

        SavePlayerData();
    }

    public static void LoadPlayerData()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/playerInfo.dat");

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            playerData = data;
        }
        else
        {
            SavePlayerDataFirstTime();
        }
    }

    public static void ResetStars()
    {
        playerData.spentStars = 0;
        playerData.normalLevel = 1;
        playerData.shooterLevel = 1;
        playerData.waveLevel = 1;
        playerData.targetLevel = 1;
        playerData.goldLevel = 1;

        playerData.gold -= playerData.starResetedTime * Constants.RESET_STARS_BASE_COST;
        playerData.starResetedTime++;
        SavePlayerData();
    }
}
