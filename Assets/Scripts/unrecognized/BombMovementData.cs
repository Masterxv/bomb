using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class BombMovementData {
    public MyVector3[] points;
    public List<float> distances;
    public float radius;
    public float speed;
    public bool isLoop;

    public BombMovementData(MyVector3[] points, List<float> distances, float radius, float speed, bool isLoop)
    {
        this.points = points;
        this.distances = distances;
        this.radius = radius;
        this.speed = speed;
        this.isLoop = isLoop;
    }
}
