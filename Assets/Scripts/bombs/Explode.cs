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

    public Explode() { }

    public Explode(Vector3 initPosition, float radius, float speed, int numPoints, float initAngle, int bulletDamage, int bulletHealth, int health, int currentHealth, int signRadius)
    {
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
