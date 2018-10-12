using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class WallRotateData: RotateData
{
    public WallRotateData(): base()
    {
    }

    public WallRotateData(bool isClockwise, float speed): base(isClockwise, speed)
    {
    }
}