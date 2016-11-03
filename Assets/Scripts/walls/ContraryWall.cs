using UnityEngine;
using System.Collections;

public class ContraryWall : Wall {

    public override void CollisionWithBullet(GameObject bullet)
    {
        Vector3 velocity = bullet.GetComponent<Rigidbody2D>().velocity;
        bullet.GetComponent<Rigidbody2D>().velocity =  Vector3.Reflect(velocity, new Vector3(-initAngle, -initAngle, 0).normalized);
    }
}
