using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class WallInfo {

    public Constants.WallTypes type;

    public int maxHealth;
    public int currentHealth;

    public float initAngle;

    public MyVector3 initPosition;

    public WallInfo()
    {
        initAngle = 0;
        initPosition = new MyVector3();
    }

    public WallInfo(Constants.WallTypes type, int maxHealth, int currentHealth, float initAngle, MyVector3 initPosition)
    {
        this.type = type;
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.initAngle = initAngle;
        this.initPosition = initPosition;
    }
}
