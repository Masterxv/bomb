using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class MovementData {
    public Constants.MovementTypes type;
    public MyVector3[] points;
    public List<float> distances;
    public float radius;
    public float speed;

    // Attributes for Circle move tyle only
    public bool isClockwise;
    public float initAngle;

    public MovementData()
    {
    }

    public MovementData(Constants.MovementTypes type, MyVector3[] points, List<float> distances, float speed, float radius, bool isClockwise, float initAngle)
    {
        this.type = type;
        this.points = points;
        this.distances = distances;
        this.radius = radius;
        this.speed = speed;
        this.isClockwise = isClockwise;
        this.initAngle = initAngle;
    }
}
