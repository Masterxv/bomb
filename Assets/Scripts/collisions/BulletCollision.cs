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
        if (other.tag == "bomb")
        {
            int bulletDamage = gameObject.GetComponent<Bullet>().damage;
            int bulletCurrentHealth = gameObject.GetComponent<Bullet>().currentHealth;
            int bombCurrentHealth = other.gameObject.GetComponent<Explode>().currentHealth;

            // Minus health of bullet and bomb
            gameObject.GetComponent<Bullet>().currentHealth = bulletCurrentHealth - bombCurrentHealth;
            other.gameObject.GetComponent<Explode>().currentHealth = bombCurrentHealth - bulletDamage;

            // Destroy object if health <= 0
            if (gameObject.GetComponent<Bullet>().currentHealth <= 0)
            {
                Destroy(gameObject);
            }
            if (other.gameObject.GetComponent<Explode>().currentHealth <= 0)
            {
                other.gameObject.GetComponent<Explode>().DoExplode();
            }
        }
    }
}
