using System;
using UnityEngine;
using System.Collections.Generic;

public class Achievement : MonoBehaviour
{
    public Constants.AchievementTypes type;
    public int level;
    public bool earned;

    public int cost;
    public int award;
    public string description;

    public float baseCost;
    public float costINC;
    public float baseAward;
    public float awardINC;

    public Achievement()
    {
    }

    public virtual void setData(int level)
    {

    }

    void Start()
    {
    }
}
