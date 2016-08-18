using UnityEngine;
using System.Collections;

public class BombInfo {

    // All bomb
    public int type;
    public Vector3 initPosition;
    public float radius;
    public float speed;
    public int numPoints;
    public float initAngle;
    public int bulletDamage;
    public int bulletHealth;
    public int health;
    public int currentHealth;
    public int signRadius;

    // Wave bomb
    public int waveWidth;

    public BombInfo() { }

    public BombInfo(int type, Vector3 initPosition, float radius, float speed, int numPoints, float initAngle, int bulletDamage, int bulletHealth, int health, int currentHealth, int signRadius, int waveWidth)
    {
        // All bomb
        this.initPosition = initPosition;
        this.radius = radius;
        this.speed = speed;
        this.numPoints = numPoints;
        this.initAngle = initAngle;
        this.bulletDamage = bulletDamage;
        this.bulletHealth = bulletHealth;
        this.health = health;
        this.currentHealth = currentHealth;
        this.signRadius = signRadius;

        // Wave bomb
        this.waveWidth = waveWidth;
    }
}
