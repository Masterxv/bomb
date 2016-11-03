using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        // Bullet collision with bomb
        if (other.gameObject.CompareTag("bomb") && !other.gameObject.GetComponent<Explode>().isExploded)
        {
            int bulletDamage = gameObject.GetComponent<Bullet>().damage;
            int bulletCurrentHealth = gameObject.GetComponent<Bullet>().currentHealth;
            int bombCurrentHealth = other.gameObject.GetComponent<Explode>().currentHealth;

            // Minus health of bullet and bomb
            gameObject.GetComponent<Bullet>().currentHealth = bulletCurrentHealth - bombCurrentHealth;
            other.gameObject.GetComponent<Explode>().currentHealth = bombCurrentHealth - bulletDamage;

            if (other.gameObject.GetComponent<Explode>().currentHealth <= 0)
            {
                other.gameObject.GetComponent<Explode>().PrepareToExplode();
            }
        }
        // Bullet colision with wall
        if(other.gameObject.CompareTag("wall"))
        {
            gameObject.GetComponent<Bullet>().CollisionWithWall(other.gameObject);
            other.gameObject.GetComponent<Wall>().CollisionWithBullet(gameObject);
        }

        // Destroy object if health <= 0
        if (gameObject.GetComponent<Bullet>().currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
