using UnityEngine;
using System.Collections;

public class AcidBullet : Bullet
{
    float duration;

    public void setData(Vector3 initPosition, Vector3 targetPosition, float distance, Vector3 velocity, int damage, int health, float duration)
    {
        base.setData(initPosition, targetPosition, distance, velocity, damage, health);
        this.duration = duration;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, initPosition) > distance)
        {
            rb.velocity = new Vector3(0, 0, 0);
            Destroy(gameObject, duration);
        }
    }
}
