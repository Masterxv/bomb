using UnityEngine;
using System.Collections;

public class BaseNormalBomb : BaseBomb
{
    public BaseNormalBomb()
    {
        radius = 7;
        speed = 20;
        numPoints = 15;
        bulletDamage = 1;
        bulletHealth = 1;
        health = 1;
        currentHealth = 1;
        signRadius = 0;
        waveWidth = 0;
    }
}
