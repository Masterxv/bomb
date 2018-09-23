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

        TextAsset asset = Resources.Load<TextAsset>("Levels/lv_" + index);
        if (asset == null)
        {
            return null;
        }
        Stream stream = new MemoryStream(asset.bytes);
        Level levelToLoad = (Level)bf.Deserialize(stream);
        stream.Close();
        currentLevel = levelToLoad;
        return levelToLoad;
    }

    public static int GetStars(int remainBombs)
    {
        if (remainBombs <= Constants.BOMB_REMAIN_3_STAR_THRESHOLD)
        {
            return 3;
        }
        else if (remainBombs <= Constants.BOMB_REMAIN_2_STAR_THRESHOLD)
        {
            return 2;
        }
        else if (remainBombs <= Constants.BOMB_REMAIN_1_STAR_THRESHOLD)
        {
            return 1;
        }
        return 0;
    }
}
