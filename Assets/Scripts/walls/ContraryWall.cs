using UnityEngine;
using System.Collections;

public class ContraryWall : Wall
{
    public Transform head;
    public Transform tail;
    public override void CollisionWithBullet(GameObject bullet)
    {
        Vector3 velocity = bullet.GetComponent<Rigidbody2D>().velocity;
        Vector3 resultVelocity = Vector3.one;
        // calculate current angle with y axis
        Vector3 wallDirection = new Vector3(head.position.x - tail.position.x, head.position.y - tail.position.y, head.position.z - tail.position.z);
        Vector3 inNormal = new Vector3(wallDirection.y, wallDirection.x * -1, wallDirection.z);
        Debug.LogError(wallDirection.ToString());
        Debug.LogError(velocity.ToString());

        //float angle = Vector3.Angle(velocity, wallDirection);
        //Debug.LogError(angle);
        //Vector3 reflectVector = Vector3.one;
        //if (angle == 0)
        //{
        //    resultVelocity = Vector3.Reflect(velocity, new Vector3(90, angle, 0).normalized);
        //}
        //else if (angle > 0)
        //{
        //    reflectVector = Vector3.Reflect(velocity, wallDirection);
        //    resultVelocity = reflectVector - new Vector3(velocity.y * -1, velocity.x *-1, velocity.z);
        //}
        //else
        //{
        //    reflectVector = Vector3.Reflect(velocity, wallDirection);
        //    resultVelocity = reflectVector - new Vector3(velocity.y * -1, velocity.x * -1, velocity.z);
        //}
        resultVelocity = Vector3.Reflect(velocity, inNormal.normalized);
        //Debug.LogError(reflectVector.ToString());
        Debug.LogError(resultVelocity.ToString());
        bullet.GetComponent<Rigidbody2D>().velocity = resultVelocity;
    }

    public override void setHealthText()
    {
        // intend to do nothing
    }
}
