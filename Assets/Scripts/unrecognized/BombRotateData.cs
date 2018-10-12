using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class BombRotateData: RotateData
{
    public BombRotateData(): base()
    {
    }

    public BombRotateData(bool isClockwise, float speed): base(isClockwise, speed)
    {
    }
}