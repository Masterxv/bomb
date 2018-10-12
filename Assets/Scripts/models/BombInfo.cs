using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[Serializable]
public class BombInfo {
    public Constants.BombTypes type;
    public MyVector3 initPosition;
    public float initAngle;
    public BombMovementData movement;
    public BombRotateData rotate;
    public float timeout;
    public bool isLocked;

    public BombInfo()
    {
        initAngle = 0;
        isLocked = false;
        timeout = 0;
        initPosition = new MyVector3();
    }

    public BombInfo(BombInfo other)
    {
        this.type = other.type;
        this.initPosition = other.initPosition;
        this.initAngle = other.initAngle;
        this.isLocked = other.isLocked;
        this.timeout = other.timeout;

        this.movement = other.movement;
        this.rotate = other.rotate;
    }

    public BombInfo(Constants.BombTypes type, MyVector3 initPosition, float initAngle, float timeout, bool isLocked, BombMovementData movement, BombRotateData rotate)
    {
        this.type = type;
        this.initPosition = initPosition;
        this.initAngle = initAngle;
        this.isLocked = isLocked;
        this.timeout = timeout;

        this.movement = movement;
        this.rotate = rotate;
    }
}
