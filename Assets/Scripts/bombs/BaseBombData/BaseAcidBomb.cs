using UnityEngine;
using System.Collections;

public class BaseAcidBomb : BaseBomb
{
    public BaseAcidBomb()
    {
        radius = 1.5f;
        speed = 10;
        numPoints = 20;
        bulletDamage = 1;
        bulletHealth = 1;
        health = 1;
        currentHealth = 1;

        bulletExistDuration = 3;

        valueInCoin = 5;
    }
}
