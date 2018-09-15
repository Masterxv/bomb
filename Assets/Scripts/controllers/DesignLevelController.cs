using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DesignLevelController : CoreController
{
    // bomb prefab
    public GameObject normalBomb;
    public GameObject shooterBomb;
    public GameObject targetBomb;
    public GameObject waveBomb;
    public GameObject acidBomb;

    // wall prefab
    public GameObject normalWall;
    public GameObject contraryWall;

    // other properties
    public int levelIndex;
    public TutorialContent tutorialContent;
    public static bool active;

    // bombs level
    public int normalLevel;
    public int shooterLevel;
    public int waveLevel;
    public int targetLevel;
    public int acidLevel;

    public void GenerateLevelData()
    {
        // Push all data to level
        // Gain bomb data
        List<BombInfo> bombInfos = new List<BombInfo>();
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("bomb");
        Debug.LogError(bombs.Length);
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

            bombInfos.Add(bombInfo);
        }

        Debug.LogError(bombInfos.Count);
        // Gain wall data
        List<WallInfo> wallInfos = new List<WallInfo>();
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
            wallInfos.Add(wallInfo);
        }

        level = new Level(levelIndex, numberOfClick, tutorialContent, bombInfos, wallInfos, extraBombs, normalLevel, shooterLevel, waveLevel, targetLevel, acidLevel);
        SaveLevelData(level);
    }

    public void SaveLevelData(Level level)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string destination = Application.dataPath + "/Resources/Levels/lv_" + level.index + ".txt";
        FileStream file = File.OpenWrite(destination);
        bf.Serialize(file, level);
        file.Close();
        // open success dialog
        showMessageDialog(true, "Notice", "Generate level succeeded!");
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

    public override void Refresh()
    {
        active = true;
        level = LevelUtil.LoadLevelData(levelIndex);
        Debug.LogError(level.bombs.Count);
        // If this level is already has, then load level data
        if (level != null)
        {
            Debug.LogError("Level it not null");
            LevelUtil.getCurrentLevel().numberOfClick = 100;
            RemoveAllCurrentBombs();
            RemoveAllCurrentWalls();
            InitBombs();
            InitWalls();
            InitTutorial();
            InitHelperPanel();
        }
        // If not then load new level data depend on current scene settings
        else
        {
            Debug.LogError("Level is NULL");
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
            List<BombInfo> bombInfos = new List<BombInfo>();
            List<WallInfo> wallInfos = new List<WallInfo>();
            level = new Level(levelIndex, numberOfClick, tutorialContent, bombInfos, wallInfos, extraBombs, normalLevel, shooterLevel, waveLevel, targetLevel, acidLevel);
            InitTutorial();
            InitHelperPanel();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
