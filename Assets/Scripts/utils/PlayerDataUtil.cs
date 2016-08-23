using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerDataUtil {

    public static PlayerData playerData;

    public static void SavePlayerData(PlayerData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite(Application.persistentDataPath + "/playerInfo.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    public static PlayerData SavePlayerDataFirstTime()
    {
        PlayerData tmpPlayerData = new PlayerData();
        tmpPlayerData.levels = new int[Constants.TOTAL_LEVEL];
        tmpPlayerData.stars = new int[Constants.TOTAL_LEVEL];
        for(int i=0; i<Constants.TOTAL_LEVEL; i++)
        {
            tmpPlayerData.levels[i] = i;
            tmpPlayerData.stars[i] = -1;
        }
        tmpPlayerData.stars[0] = 1;
        tmpPlayerData.stars[1] = 2;
        tmpPlayerData.stars[2] = 3;
        tmpPlayerData.stars[3] = 0;

        SavePlayerData(tmpPlayerData);
        return tmpPlayerData;
    }

    public static PlayerData LoadPlayerData()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/playerInfo.dat");

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            return data;
        }
        return SavePlayerDataFirstTime();
    }
}
