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
        playerData.stars[0] = 1;
        playerData.stars[1] = 2;
        playerData.stars[2] = 3;
        playerData.stars[3] = 3;
        playerData.stars[4] = 3;
        playerData.stars[5] = 3;
        playerData.stars[6] = 3;
        playerData.stars[7] = 3;
        playerData.stars[8] = 0;

        playerData.normalLevel = 1;
        playerData.shooterLevel = 1;
        playerData.waveLevel = 1;
        playerData.targetLevel = 1;

        playerData.normalExtra = 0;
        playerData.shooterExtra = 0;
        playerData.waveExtra = 0;
        playerData.targetExtra = 0;

        playerData.earnedStars = 21;
        playerData.spentStars = 0;
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
}
