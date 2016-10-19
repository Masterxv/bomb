using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

public class DesignLevelController : MonoBehaviour
{
    public GameObject normalBomb;
    public GameObject shooterBomb;
    public GameObject targetBomb;
    public GameObject waveBomb;
    public GameObject acidBomb;


    private Level level;
    public int levelIndex;
    public int numberOfClick;

    public string tutorialContent;
    public string tutorialImage;


    public void GenerateLevelData()
    {
        // Push all data to level
        level = new Level();
        level.index = levelIndex;
        level.numberOfClick = numberOfClick > 0 ? numberOfClick : 1;
        level.tutorialContent = tutorialContent;
        level.tutorialImage = tutorialImage;

        level.bombs = new List<BombInfo>();
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");
        for (int i = 0; i < bombs.Length; i++)
        {
            GameObject bomb = bombs[i];
            BombInfo bombInfo = new BombInfo();
           
            bombInfo.initAngle = -1 * bomb.GetComponent<Explode>().initAngle;
            bombInfo.type = bomb.GetComponent<Explode>().type;
            BombMovement bombMovement = bomb.GetComponent<BombMovement>();
            if (bombMovement.speed > 0)
            {
                bombInfo.initPosition.Fill(bomb.GetComponent<Explode>().initPosition);
                MyVector3[] points = new MyVector3[bombMovement.points.Count];
                for (int j = 0; j < bombMovement.points.Count; j++)
                {
                    points[j] = new MyVector3();
                    points[j].Fill(bombMovement.points[j]);
                }
                bombInfo.movement = new BombMovementData(bombMovement.type, points, bombMovement.distances, bombMovement.speed, bombMovement.radius, bombMovement.isClockwise);
            }
            else
            {
                bombInfo.initPosition.Fill(bomb.transform.position);
                bombInfo.movement = null;
            }

            level.bombs.Add(bombInfo);
        }

        // Save level data to file
        SaveLevelData(level);
    }

    public void SaveLevelData(Level level)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string destination = Application.dataPath + "/data/lv" + level.index + ".txt";
        FileStream file = File.OpenWrite(destination);
        bf.Serialize(file, level);
        file.Close();
        FileUtil.ReplaceFile(destination, Application.dataPath + "/Resources/Levels/lv" + level.index + ".txt");
    }

    void InitBombs(Level level)
    {
        // Init all bombs in level
        for (int i = 0; i < level.bombs.Count; i++)
        {
            BombInfo bombInfo = level.bombs[i];
            GameObject bomb = null;
            switch (bombInfo.type)
            {
                case Constants.BombTypes.normal:
                    bomb = Instantiate(normalBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.BombTypes.shooter:
                    bomb = Instantiate(shooterBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.BombTypes.target:
                    bomb = Instantiate(targetBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.BombTypes.wave:
                    bomb = Instantiate(waveBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.BombTypes.acid:
                    bomb = Instantiate(acidBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
            }
            if (bomb == null)
            {
                bomb = Instantiate(normalBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
            }
            bomb.GetComponent<Explode>().setBombData(bombInfo);
            if (bombInfo.movement == null)
            {
                bomb.GetComponent<BombMovement>().enabled = false;
            }
            else
            {
                bomb.GetComponent<BombMovement>().SetMovementData(bombInfo.movement);
            }
        }
    }

    void RemoveAllCurrentBombs()
    {
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");
        for (int i = 0; i < bombs.Length; i++)
        {
            Destroy(bombs[i]);
        }
    }

    void InitTutorial(string content, string imageName)
    {
        if (content == "")
        {
            GameObject.Find("Tutorial").SetActive(false);
        }
        else
        {
            GameObject.Find("Tutorial").GetComponentInChildren<Text>().text = content;
            GameObject.Find("Tutorial").GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/tutorials/" + imageName);
        }
        tutorialContent = content;
        tutorialImage = imageName;
    }

    public void Refresh()
    {
        PlayerDataUtil.SavePlayerDataFirstTime();
        level = LevelUtil.LoadLevelData(levelIndex);
        // If this level is already has, then load level data
        if (level != null)
        {
            LevelUtil.getCurrentLevel().numberOfClick = 100;
            RemoveAllCurrentBombs();
            InitBombs(level);
            InitTutorial(level.tutorialContent, level.tutorialImage);
        }
        // If not then load new level data depend on current scene settings
        else
        {
            GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");
            for (int i = 0; i < bombs.Length; i++)
            {
                GameObject bomb = bombs[i];
                bomb.GetComponent<Explode>().initPosition = bomb.transform.position;
            }
            InitTutorial(tutorialContent, tutorialImage);
        }
    }

    void Awake()
    {
        Refresh();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
