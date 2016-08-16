using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelUtil {

    public static List<Level> levels = new List<Level>();

    public static void init()
    {
        // Level 1
        Level level_1 = new Level();
        level_1.index = 1;
        level_1.tutorial = "Click on any bomb, lol!";
        level_1.explodes = new List<Explode>();
        //public Explode(Vector3 initPosition, float radius, float speed, int numPoints, float initAngle, int bulletDamage, int bulletHealth, int health, int currentHealth, int signRadius)
        Explode normal_1 = new NormalExplode(new Vector3(0, 0, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        Explode normal_2 = new NormalExplode(new Vector3(0, 1, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        level_1.explodes.Add(normal_1);
        level_1.explodes.Add(normal_2);
   
        levels.Add(level_1);

        // Level 2
        Level level_2 = new Level();
        level_2.index = 2;
        level_2.tutorial = "Click on any bomb, lol!";
        level_2.explodes = new List<Explode>();
        //public Explode(Vector3 initPosition, float radius, float speed, int numPoints, float initAngle, int bulletDamage, int bulletHealth, int health, int currentHealth, int signRadius)
        normal_1 = new NormalExplode(new Vector3(0, 0, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        normal_2 = new NormalExplode(new Vector3(0, 1, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        level_2.explodes.Add(normal_1);
        level_2.explodes.Add(normal_2);

        levels.Add(level_2);

        // Level 3
        Level level_3 = new Level();
        level_3.index = 3;
        level_3.tutorial = "Click on any bomb, lol!";
        level_3.explodes = new List<Explode>();
        //public Explode(Vector3 initPosition, float radius, float speed, int numPoints, float initAngle, int bulletDamage, int bulletHealth, int health, int currentHealth, int signRadius)
        normal_1 = new NormalExplode(new Vector3(0, 0, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        normal_2 = new NormalExplode(new Vector3(0, 1, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        level_3.explodes.Add(normal_1);
        level_3.explodes.Add(normal_2);

        levels.Add(level_3);

        // Level 4
        Level level_4 = new Level();
        level_4.index = 4;
        level_4.tutorial = "Click on any bomb, lol!";
        level_4.explodes = new List<Explode>();
        //public Explode(Vector3 initPosition, float radius, float speed, int numPoints, float initAngle, int bulletDamage, int bulletHealth, int health, int currentHealth, int signRadius)
        normal_1 = new NormalExplode(new Vector3(0, 0, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        normal_2 = new NormalExplode(new Vector3(0, 1, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        level_4.explodes.Add(normal_1);
        level_4.explodes.Add(normal_2);

        levels.Add(level_4);

        // Level 5
        Level level_5 = new Level();
        level_5.index = 5;
        level_5.tutorial = "Click on any bomb, lol!";
        level_5.explodes = new List<Explode>();
        //public Explode(Vector3 initPosition, float radius, float speed, int numPoints, float initAngle, int bulletDamage, int bulletHealth, int health, int currentHealth, int signRadius)
        normal_1 = new NormalExplode(new Vector3(0, 0, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        normal_2 = new NormalExplode(new Vector3(0, 1, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        level_5.explodes.Add(normal_1);
        level_5.explodes.Add(normal_2);

        levels.Add(level_5);

        // Level 6
        Level level_6 = new Level();
        level_6.index = 6;
        level_6.tutorial = "Click on any bomb, lol!";
        level_6.explodes = new List<Explode>();
        //public Explode(Vector3 initPosition, float radius, float speed, int numPoints, float initAngle, int bulletDamage, int bulletHealth, int health, int currentHealth, int signRadius)
        normal_1 = new NormalExplode(new Vector3(0, 0, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        normal_2 = new NormalExplode(new Vector3(0, 1, 0), 3, 10, 10, 0, 1, 1, 1, 1, 3);
        level_6.explodes.Add(normal_1);
        level_6.explodes.Add(normal_2);

        levels.Add(level_6);
    }

    public static Level getLevel(int index)
    {
        return levels[index];
    }
}
