using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class WallMovementData: MovementData
{
    public WallMovementData(): base()
    {
    }

    public WallMovementData(Constants.MovementTypes type, MyVector3[] points, List<float> distances, float speed, float radius, bool isClockwise, float initAngle): base(type, points, distances, speed, radius, isClockwise, initAngle)
    {
    }
}

