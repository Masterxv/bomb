using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject signPrefab;

    public float radius;
    public float speed;
    public int numPoints;
    public float initAngle;
    public int bulletDamage;
    public int bulletHealth;
    public int health;
    public int currentHealth;
    public int signRadius;
    public Vector3 initPosition;

    public virtual void setBombData(BombInfo bombInfo)
    {
        radius = bombInfo.radius;
        speed = bombInfo.speed;
        numPoints = bombInfo.numPoints;
        initAngle = bombInfo.initAngle;
        bulletDamage = bombInfo.bulletDamage;
        bulletHealth = bombInfo.bulletHealth;
        health = bombInfo.health;
        currentHealth = bombInfo.currentHealth;
        signRadius = bombInfo.signRadius;
        initPosition = bombInfo.initPosition;
    }

    // Use this for initialization
    public virtual void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        DoExplode();
    }

    public virtual void DoExplode()
    {

    }
}
