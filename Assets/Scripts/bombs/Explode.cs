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
