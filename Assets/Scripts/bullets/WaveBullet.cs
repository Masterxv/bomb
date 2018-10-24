using UnityEngine;
using System.Collections;

public class WaveBullet : Bullet
{
    void Update()
    {
        if (Vector3.Distance(transform.position, initPosition) > distance)
        {
            rb.velocity = new Vector3(0, 0, 0);
            Destroy(gameObject);
        }
    }

}
