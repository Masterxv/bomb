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
        tmpPlayerData.levels = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        tmpPlayerData.stars = new int[] { 0, 1, 2, 3, -1, -1, -1, -1, -1, -1 };
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
