using UnityEngine;
using System.Collections;

public class BaseWaveBomb : BaseBomb
{
    public BaseWaveBomb()
    {
        radius = 100;
        speed = 8;
        numPoints = 2;
        bulletDamage = 1;
        bulletHealth = 1;
        health = 1;
        currentHealth = 1;
        signRadius = 3;
        waveWidth = 2;
        valueInCoin = 2;
    }
}
