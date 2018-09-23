using UnityEngine;
using System.Collections;

public class BaseShooterBomb : BaseBomb
{
    public BaseShooterBomb()
    {
        radius = 100;
        speed = 5;
        numPoints = 2;
        bulletDamage = 1;
        bulletHealth = 1;
        health = 1;
        currentHealth = 1;

        signRadius = 0.8f;

        valueInCoin = 5;
    }
}
