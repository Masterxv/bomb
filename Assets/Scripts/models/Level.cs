using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level {
    public int index;
    public string name;
    public List<BombInfo> bombs;
    public string tutorial;

    public Level()
    {

    }

    public Level(int index, string name, List<BombInfo> bombs, string tutorial)
    {
        this.index = index;
        this.name = name;
        this.bombs = bombs;
        this.tutorial = tutorial;
    }
}
