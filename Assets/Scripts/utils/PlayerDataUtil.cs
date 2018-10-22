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
        //Debug.LogError(Application.persistentDataPath);
        FileStream file = File.OpenWrite(Application.persistentDataPath + "/playerInfo.dat");
        bf.Serialize(file, playerData);
        file.Close();
    }

    public static void SavePlayerDataFirstTime()
    {
        playerData = new PlayerData();
        playerData.unlockedLevelIndex = 1;
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
}
