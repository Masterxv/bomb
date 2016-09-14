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

    public BombInfo()
    {
        initAngle = 0;
        initPosition = new MyVector3();
        movement = new BombMovementData();
    }

    public BombInfo(Constants.BombTypes type, MyVector3 initPosition, float initAngle, BombMovementData movement)
    {
        this.type = type;
        this.initPosition = initPosition;
        this.initAngle = initAngle;
        this.movement = movement;
    }
}
