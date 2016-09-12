using UnityEngine;
using System.Collections;

public class BaseShooterBomb : BaseBomb
{
    public BaseShooterBomb()
    {
        radius = 100;
        speed = 25;
        numPoints = 2;
        bulletDamage = 1;
        bulletHealth = 1;
        health = 1;
        currentHealth = 1;

        signRadius = 3;

        valueInCoin = 5;
    }
}
