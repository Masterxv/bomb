using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class BombInfo {
    public Constants.BombTypes type;
    public float x;
    public float y;
    public float z;
    public float initAngle = 0;

    public BombInfo()
    {

    }

    public BombInfo(Constants.BombTypes type, Vector3 initPosition, float initAngle)
    {
        this.type = type;
        this.x = initPosition.x;
        this.y = initPosition.y;
        this.z = initPosition.z;
        this.initAngle = initAngle;
    }
}
