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
        if (other.tag == "bullet")
        {
            Debug.Log("Another Bullet");
            return;
        }

        if (other.tag == "bomb")
        {
            Debug.Log("Another Bomb");
            Destroy(gameObject);
            other.gameObject.GetComponent<Explode>().DoExplode();
        }
    }
}
