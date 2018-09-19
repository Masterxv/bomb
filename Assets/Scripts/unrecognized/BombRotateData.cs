using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class BombRotateData
{
    public bool isClockwise;
    public float speed;

    public BombRotateData()
    {

    }

    public BombRotateData(bool isClockwise, float speed)
    {
        this.isClockwise = isClockwise;
        this.speed = speed;
    }
}