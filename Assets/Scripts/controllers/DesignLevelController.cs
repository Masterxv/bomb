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

    public GameObject normalWall;
    public GameObject contraryWall;


    private Level level;
    public int levelIndex;
    public int numberOfClick;

    public TutorialContent tutorialContent;

    public static bool active;


    public void GenerateLevelData()
    {
        // Push all data to level
        level = new Level();
        level.index = levelIndex;
        level.numberOfClick = numberOfClick > 0 ? numberOfClick : 1;
        level.tutorialContent = tutorialContent;

        // Gain bomb data
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

        // Gain wall data
        level.walls = new List<WallInfo>();
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        for (int i = 0; i < walls.Length; i++)
        {
            GameObject wall = walls[i];
            WallInfo wallInfo = new WallInfo();
            wallInfo.initAngle = -1 * wall.GetComponent<Wall>().initAngle;
            wallInfo.initPosition.Fill(wall.transform.position);
            wallInfo.maxHealth = wall.GetComponent<Wall>().maxHealth;
            wallInfo.currentHealth = wall.GetComponent<Wall>().currentHealth;
            wallInfo.type = wall.GetComponent<Wall>().type;
            level.walls.Add(wallInfo);
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
        //FileUtil.ReplaceFile(destination, Application.dataPath + "/Resources/Levels/lv" + level.index + ".txt");
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

    void InitWalls(Level level)
    {
        for(var i=0; i<level.walls.Count; i++)
        {
            WallInfo wallInfo = level.walls[i];
            GameObject wall = null;
            switch(wallInfo.type)
            {
                case Constants.WallTypes.normal:
                    wall = Instantiate(normalWall, wallInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
                case Constants.WallTypes.contrary:
                    wall = Instantiate(contraryWall, wallInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                    break;
            }
            if (wall == null)
            {
                wall = Instantiate(normalWall, wallInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
            }
            wall.GetComponent<Wall>().setWallData(wallInfo);
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

    void RemoveAllCurrentWalls()
    {
        GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
        for (int i = 0; i < walls.Length; i++)
        {
            Destroy(walls[i]);
        }
    }

    void InitTutorial(string descriptions, string imageName)
    {
        if (descriptions == "")
        {
            GameObject.Find("Tutorial").SetActive(false);
        }
        else
        {
            GameObject.Find("Tutorial").GetComponentInChildren<Text>().text = descriptions;
            GameObject.Find("Tutorial").GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/tutorials/" + imageName);
        }
        tutorialContent = new TutorialContent("", descriptions, imageName);
    }

    public void Refresh()
    {
        active = true;
        PlayerDataUtil.SavePlayerDataFirstTime(); // TODO: remove in production
        PlayerDataUtil.LoadPlayerData(); // TODO: remove in production
        level = LevelUtil.LoadLevelData(levelIndex);
        // If this level is already has, then load level data
        if (level != null)
        {
            Debug.LogError("Level it not null");
            LevelUtil.getCurrentLevel().numberOfClick = 100;
            RemoveAllCurrentBombs();
            RemoveAllCurrentWalls();
            InitBombs(level);
            InitWalls(level);
            InitTutorial(level.tutorialContent.descriptions, level.tutorialContent.image);
        }
        // If not then load new level data depend on current scene settings
        else
        {
            Debug.LogError("Level it NULL");
            GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");
            for (int i = 0; i < bombs.Length; i++)
            {
                GameObject bomb = bombs[i];
                bomb.GetComponent<Explode>().initPosition = bomb.transform.position;
            }

            GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
            for(int i=0; i<walls.Length; i++)
            {
                GameObject wall = walls[i];
                wall.GetComponent<Wall>().initPosition = wall.transform.position;
                RectTransform [] healthsTransform = wall.GetComponentsInChildren<RectTransform>();
                healthsTransform[1].sizeDelta = new Vector2(healthsTransform[1].sizeDelta.x, wall.GetComponent<Wall>().maxHealth*Constants.WALL_HEALTH_UNIT);
                healthsTransform[2].sizeDelta = new Vector2(healthsTransform[2].sizeDelta.x, wall.GetComponent<Wall>().currentHealth*Constants.WALL_HEALTH_UNIT);
                wall.GetComponent<BoxCollider2D>().size = new Vector2(wall.GetComponent<BoxCollider2D>().size.x, wall.GetComponent<BoxCollider2D>().size.y * wall.GetComponent<Wall>().maxHealth / 2);
            }
            InitTutorial(tutorialContent.descriptions, tutorialContent.image);
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
