using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[Serializable]
public class BombInfo {
    public Constants.BombTypes type;
    public MyVector3 initPosition;
    public float initAngle = 0;
    public BombMovementData movement;

    public BombInfo()
    {

    }

    public BombInfo(Constants.BombTypes type, MyVector3 initPosition, float initAngle, BombMovementData movement)
    {
        this.type = type;
        this.initPosition = initPosition;
        this.initAngle = initAngle;
        this.movement = movement;
    }
}
