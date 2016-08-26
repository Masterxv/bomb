using UnityEngine;
using System.Collections;

public class BaseTargetBomb : BaseBomb
{
    public BaseTargetBomb()
    {
        radius = 100;
        speed = 30;
        numPoints = 2;
        bulletDamage = 1;
        bulletHealth = 1;
        health = 1;
        currentHealth = 1;
        signRadius = 0;
        waveWidth = 0;
        valueInCoin = 3;
    }
}
