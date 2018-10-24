using System;
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    protected Rigidbody2D rb;
    public Vector3 initPosition { get; set; }
    public Vector3 targetPosition { get; set; }
    public Vector3 velocity { get; set; }
    public float distance { get; set; }
    public int damage { get; set; }
    public int health { get; set; }
    public int currentHealth { get; set; }
    private float expiredTime;
    private float existDuration;

    public virtual void setData(Vector3 initPosition, Vector3 targetPosition, float distance, Vector3 velocity, int damage, int health)
    {
        this.initPosition = initPosition;
        this.targetPosition = targetPosition;
        this.distance = distance;
        this.velocity = velocity;
        this.damage = damage;
        this.health = health;
    }

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
        currentHealth = health;
        expiredTime = Constants.BULLET_EXPIRED_TIME;
        existDuration = 0;
    }

    public virtual void Update () {
        existDuration += Time.deltaTime;
        if (existDuration > expiredTime)
        {
            Destroy(gameObject);
        }
    }

    public virtual void CollisionWithWall(GameObject wall)
    {
        if (wall.GetComponent<Wall>().type == Constants.WallTypes.normal)
        {
            currentHealth = 0;
        }
    }
}
