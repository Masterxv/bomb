using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelUtil
{
    private static Level currentLevel;

    public static void init()
    {
    }

    public static Level getCurrentLevel()
    {
        return currentLevel;
    }

    public static void setCurrentLevel(Level level)
    {
        currentLevel = level;
    }

    public static Level LoadLevelData(int index)
    {
        if (File.Exists(Application.dataPath + "/data/lv" + index + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.dataPath + "/data/lv" + index + ".dat");

            Level levelToLoad = (Level)bf.Deserialize(file);
            file.Close();
            return levelToLoad;
        }
        return null;
    }
}
