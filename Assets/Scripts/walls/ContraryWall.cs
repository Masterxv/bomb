using UnityEngine;
using System.Collections;

public class ContraryWall : Wall
{

    public override void CollisionWithBullet(GameObject bullet)
    {
        Vector3 velocity = bullet.GetComponent<Rigidbody2D>().velocity;
        Vector3 resultVelocity = Vector3.one;
        if (initAngle == 0)
        {
            resultVelocity = Vector3.Reflect(velocity, new Vector3(90, initAngle, 0).normalized);
        }
        else if (initAngle > 0)
        {
            resultVelocity = Vector3.Reflect(velocity, new Vector3(-initAngle, -initAngle, 0).normalized);
        }
        else
        {
            resultVelocity = Vector3.Reflect(velocity, new Vector3(-initAngle, initAngle, 0).normalized);
        }
        bullet.GetComponent<Rigidbody2D>().velocity = resultVelocity;
    }
}
