using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class ExtraBombInfo
{
    public Constants.BombTypes bombType;
    public int count;

    public ExtraBombInfo() { }

    public ExtraBombInfo(Constants.BombTypes bombType, int count)
    {
        this.bombType = bombType;
        this.count = count;
    }
}