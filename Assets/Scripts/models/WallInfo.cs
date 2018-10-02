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

    public WallMovementData movement;
    public WallRotateData rotate;

    public WallInfo()
    {
        initAngle = 0;
        initPosition = new MyVector3();
        movement = new WallMovementData();
        rotate = new WallRotateData();
    }

    public WallInfo(WallInfo other)
    {
        this.type = other.type;
        this.initPosition = other.initPosition;
        this.initAngle = other.initAngle;
        this.currentHealth = other.currentHealth;
        this.maxHealth = other.maxHealth;
        this.movement = other.movement;
        this.rotate = other.rotate;
    }

    public WallInfo(Constants.WallTypes type, int maxHealth, int currentHealth, float initAngle, MyVector3 initPosition, WallMovementData movement, WallRotateData rotate)
    {
        this.type = type;
        this.initAngle = initAngle;
        this.initPosition = initPosition;
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.movement = movement;
        this.rotate = rotate;
    }
}
