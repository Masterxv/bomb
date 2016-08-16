using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level {
    public int index;
    public string name;
    public List<Explode> explodes;
    public string tutorial;

    public Level()
    {

    }

    public Level(int index, string name, List<Explode> explodes, string tutorial)
    {
        this.index = index;
        this.name = name;
        this.explodes = explodes;
        this.tutorial = tutorial;
    }
}
