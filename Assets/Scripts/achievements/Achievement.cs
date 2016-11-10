using System;
using UnityEngine;
using UnityEngine.UI;
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

    public int progress;

    public Achievement()
    {
    }

    public virtual void setData(int level)
    {

    }

    void Start()
    {
        GetComponentInChildren<Text>().text = progress + " %";
        GetComponent<Button>().onClick.AddListener(() => AchievementController.instance.AchievementClicked(this));
    }
}
