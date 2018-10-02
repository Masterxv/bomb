using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombMovementData: MovementData {
    public BombMovementData(): base()
    {
    }

    public BombMovementData(Constants.MovementTypes type, MyVector3[] points, List<float> distances, float speed, float radius, bool isClockwise): base(type, points, distances, speed, radius, isClockwise)
    {
    }
}
