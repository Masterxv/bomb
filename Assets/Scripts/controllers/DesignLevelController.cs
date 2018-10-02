using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DG.Tweening;

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

    // override level data
    public bool overrideLevelData;

    Level backupLevel;

    public void GenerateLevelData(bool withBackup=false)
    {
        Debug.Log(withBackup);
        if (withBackup)
        {
            level = backupLevel;
        }
        else
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

                BombRotate bombRotate = bomb.GetComponent<BombRotate>();
                if (bombRotate.speed > 0)
                {
                    bombInfo.rotate = new BombRotateData(bombRotate.isClockwise, bombRotate.speed);
                }
                else
                {
                    bombInfo.rotate = null;
                }

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

            // Gain wall data
            List<WallInfo> wallInfos = new List<WallInfo>();
            GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");
            for (int i = 0; i < walls.Length; i++)
            {
                GameObject wall = walls[i];
                WallInfo wallInfo = new WallInfo();
                wallInfo.initAngle = wall.GetComponent<Wall>().initAngle;
                wallInfo.initPosition.Fill(wall.transform.position);
                wallInfo.maxHealth = wall.GetComponent<Wall>().maxHealth;
                wallInfo.currentHealth = wall.GetComponent<Wall>().currentHealth;
                wallInfo.type = wall.GetComponent<Wall>().type;

                WallRotate wallRotate = wall.GetComponent<WallRotate>();
                if (wallRotate.speed > 0)
                {
                    wallInfo.rotate = new WallRotateData(wallRotate.isClockwise, wallRotate.speed);
                }
                else
                {
                    wallInfo.rotate = null;
                }

                WallMovement wallMovement = wall.GetComponent<WallMovement>();
                if (wallMovement.speed > 0)
                {
                    wallInfo.initPosition.Fill(wall.GetComponent<Explode>().initPosition);
                    MyVector3[] points = new MyVector3[wallMovement.points.Count];
                    for (int j = 0; j < wallMovement.points.Count; j++)
                    {
                        points[j] = new MyVector3();
                        points[j].Fill(wallMovement.points[j]);
                    }
                    wallInfo.movement = new WallMovementData(wallMovement.type, points, wallMovement.distances, wallMovement.speed, wallMovement.radius, wallMovement.isClockwise);
                }
                else
                {
                    wallInfo.initPosition.Fill(wall.transform.position);
                    wallInfo.movement = null;
                }

                wallInfos.Add(wallInfo);
            }

            level = new Level(levelIndex, numberOfClick, tutorialContent, bombInfos, wallInfos, extraBombs, normalLevel, shooterLevel, waveLevel, targetLevel, acidLevel);
            backupLevel = level;
        }
    }

    public void SaveGeneratedData()
    {
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

    public override void Refresh(bool withBackup)
    {
        ended = false;
        resultPanel.transform.localScale = new Vector3(0.1f, 0.1f, 0);
        active = true;
        clickedNumber = 0;
        if (overrideLevelData)
        {
            Debug.LogError("Override level data");
            level = null;
        }
        else
        {
            level = LevelUtil.LoadLevelData(levelIndex);
        }

        // If this level is already has, then load level data
        if (level == null)
        {
            Debug.LogError("Level is NULL");
            GenerateLevelData(withBackup);
        }
        else
        {
            Debug.LogError("Level it not null");
        }

        resultPanel.SetActive(false);
        RemoveAllCurrentBombs();
        RemoveAllCurrentWalls();
        InitBombs();
        InitWalls();
        InitTutorial();
        InitHelperPanel();
    }
}
