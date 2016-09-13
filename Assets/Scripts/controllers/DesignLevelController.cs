using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DesignLevelController : MonoBehaviour
{
    public GameObject normalBomb;
    public GameObject shooterBomb;
    public GameObject targetBomb;
    public GameObject waveBomb;
    public GameObject acidBomb;

    public int levelIndex;
    public string tutorialContent;
    public string tutorialImage;
    private Level level;


    void GenerateLevelData()
    {
        // Push all data to level
        level = new Level();
        level.index = levelIndex;
        level.tutorialContent = tutorialContent;
        level.tutorialImage = tutorialImage;

        level.bombs = new List<BombInfo>();
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");
        for (int i = 0; i < bombs.Length; i++)
        {
            GameObject bomb = bombs[i];
            BombInfo bombInfo = new BombInfo();
            bombInfo.initPosition.Fill(transform.position);
            bombInfo.initAngle = -1 * bomb.GetComponent<Explode>().initAngle;
            bombInfo.type = bomb.GetComponent<Explode>().type;
            BombMovement bombMovement = bomb.GetComponent<BombMovement>();
            MyVector3[] points = new MyVector3[bombMovement.points.Count];
            for (int j = 0; j < bombMovement.points.Count; j++)
            {
                points[j] = new MyVector3();
                points[j].Fill(bombMovement.points[j]);
            }
            bombInfo.movement = new BombMovementData(bombMovement.type, points, bombMovement.distances, bombMovement.speed, bombMovement.radius, bombMovement.isClockwise);
            level.bombs.Add(bombInfo);
        }

        // Save level data to file
        SaveLevelData(level);
    }

    public void SaveLevelData(Level level)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.OpenWrite(Application.dataPath + "/data/lv" + level.index + ".dat");
        bf.Serialize(file, level);
        file.Close();
    }

    public Level LoadLevelData(int index)
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

    // Use this for initialization
    void Start()
    {
        GameObject generator = GameObject.Find("Generate");
        Button generateBtn = generator.GetComponent<Button>();
        generateBtn.onClick.AddListener(() => GenerateLevelData());

        // Init tutorials
        if (tutorialContent == "")
        {
            GameObject.Find("Tutorial").SetActive(false);
        }
        else
        {
            GameObject.Find("Tutorial").GetComponentInChildren<Text>().text = tutorialContent;
            GameObject.Find("Tutorial").GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/tutorials/" + tutorialImage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
