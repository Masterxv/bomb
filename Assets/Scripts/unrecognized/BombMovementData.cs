using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class BombMovementData {
    public Constants.MovementTypes type;
    public MyVector3[] points;
    public List<float> distances;
    public float radius;
    public float speed;
    public bool isClockwise;

    public BombMovementData()
    {

    }

    public BombMovementData(Constants.MovementTypes type, MyVector3[] points, List<float> distances, float speed, float radius, bool isClockwise)
    {
        this.type = type;
        this.points = points;
        this.distances = distances;
        this.radius = radius;
        this.speed = speed;
        this.isClockwise = isClockwise;
    }
}
