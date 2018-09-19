using UnityEngine;
using System.Collections;

public class BaseNormalBomb : BaseBomb
{
    public BaseNormalBomb()
    {
        radius = 2;
        speed = 5;
        numPoints = 15;
        bulletDamage = 1;
        bulletHealth = 1;
        health = 1;
        currentHealth = 1;

        valueInCoin = 5;
    }
}
