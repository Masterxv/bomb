﻿using UnityEngine;
using System.Collections;

public class BaseAcidBomb : BaseBomb
{
    public BaseAcidBomb()
    {
        radius = 6;
        speed = 10;
        numPoints = 20;
        bulletDamage = 1;
        bulletHealth = 1;
        health = 1;
        currentHealth = 1;

        duration = 3;

        valueInCoin = 5;
    }
}