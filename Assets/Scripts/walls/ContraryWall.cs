using UnityEngine;
using System.Collections;

public class ContraryWall : Wall
{
    public Transform head;
    public Transform tail;
    public override void CollisionWithBullet(GameObject bullet)
    {
        Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();
        Vector3 velocity = bulletRigidbody2D.velocity;
        Vector3 resultVelocity = Vector3.one;
        // calculate current angle with y axis
        Vector3 wallDirection = new Vector3(head.position.x - tail.position.x, head.position.y - tail.position.y, head.position.z - tail.position.z);
        Vector3 inNormal = new Vector3(wallDirection.y, wallDirection.x * -1, wallDirection.z);
        resultVelocity = Vector3.Reflect(velocity, inNormal.normalized);
        bulletRigidbody2D.velocity = resultVelocity;
    }

    public override void setHealthText()
    {
        // intend to do nothing
    }
}
