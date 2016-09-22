using UnityEngine;
using UnityEngine.UI;
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
        if(currentLevel == null)
        {
            currentLevel = LoadLevelData(1);
        }
        return currentLevel;
    }

    public static void setCurrentLevel(Level level)
    {
        currentLevel = level;
    }

    public static Level LoadLevelData(int index)
    {
        BinaryFormatter bf = new BinaryFormatter();

        //FileStream file = File.OpenRead(Application.dataPath + "/data/lv" + index + ".dat");
        //Level levelToLoad = (Level)bf.Deserialize(file);
        //file.Close();
        // return null;

        TextAsset asset = Resources.Load<TextAsset>("Levels/lv" + index);
        if (asset == null)
        {
            return null;
        }
        Stream stream = new MemoryStream(asset.bytes);
        Level levelToLoad = (Level)bf.Deserialize(stream);
        stream.Close();

        return levelToLoad;
    }
}
