using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {

    private bool collided;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(collided)
        {
            return;
        }
      
        if (other.tag == "bullet")
        {
            Debug.Log("Another Bullet");
            return;
        }

        if (other.tag == "bomb")
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Explode>().DoExplode();
            collided = true;
        }
    }
}
