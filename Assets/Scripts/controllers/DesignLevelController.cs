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
            bombInfo.x = bomb.transform.position.x;
            bombInfo.y = bomb.transform.position.y;
            bombInfo.z = bomb.transform.position.z;
            bombInfo.initAngle = -1*bomb.GetComponent<Explode>().initAngle;
            bombInfo.type = bomb.GetComponent<Explode>().type;
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

        //BombInfo normal = new BombInfo(Constants.BombTypes.normal, new Vector3(0, 0, 0), 0);
        //BombInfo shooter = new BombInfo(Constants.BombTypes.shooter, new Vector3(0, 5, 0), 0);
        //BombInfo target = new BombInfo(Constants.BombTypes.target, new Vector3(0, 10, 0), 0);
        //BombInfo wave = new BombInfo(Constants.BombTypes.wave, new Vector3(0, 15, 0), 0);
        //level.bombs.Add(normal);
        //level.bombs.Add(shooter);
        //level.bombs.Add(target);
        //level.bombs.Add(wave);

        //// Init all bombs in level
        //for (int i = 0; i < level.bombs.Count; i++)
        //{
        //    BombInfo bombInfo = level.bombs[i];
        //    GameObject bomb = null;
        //    switch (bombInfo.type)
        //    {
        //        case Constants.BombTypes.normal:
        //            bomb = Instantiate(normalBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
        //            break;
        //        case Constants.BombTypes.shooter:
        //            bomb = Instantiate(shooterBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
        //            break;
        //        case Constants.BombTypes.target:
        //            bomb = Instantiate(targetBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
        //            break;
        //        case Constants.BombTypes.wave:
        //            bomb = Instantiate(waveBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
        //            break;
        //    }
        //    if (bomb == null)
        //    {
        //        bomb = Instantiate(normalBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
        //    }
        //    bomb.GetComponent<Explode>().setBombData(bombInfo);
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
