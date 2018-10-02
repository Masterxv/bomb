using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class RotateData
{
    public bool isClockwise;
    public float speed;

    public RotateData()
    {

    }

    public RotateData(bool isClockwise, float speed)
    {
        this.isClockwise = isClockwise;
        this.speed = speed;
    }
}