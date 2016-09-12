using UnityEngine;
using System.Collections;

public class BaseBomb {
    public float radius;
    public float speed;
    public int numPoints;
    public int bulletDamage;
    public int bulletHealth;
    public int health;
    public int currentHealth;

    public int signRadius; // only for shooter and wave bomb

    public int waveWidth; // only for Wave bomb
    public float duration; // only for Acid bomb

    public int valueInCoin;
}
