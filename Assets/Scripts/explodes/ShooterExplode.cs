using UnityEngine;
using System.Collections;

public class ShooterExplode : Explode
{
    public override void DoExplode()
    {
        Vector3 thisPosition = transform.position;
        Destroy(gameObject); // Destroy this game object

        for (int pointNum = 0; pointNum < numPoints; pointNum++)
        {
            float i = (pointNum * 1.0f) / numPoints;
            float angle = i * Mathf.PI * 2;
            float x = Mathf.Sin(angle) * radius;
            float y = Mathf.Cos(angle) * radius;
            Vector3 targetPosition = new Vector3(x, y, 0) + thisPosition;

            GameObject newBullet = Instantiate(bullet, thisPosition, Quaternion.identity) as GameObject;
            newBullet.GetComponent<BulletMove>().setInitPosition(thisPosition);
            newBullet.GetComponent<BulletMove>().setTargetPosition(targetPosition);
            Vector3 velocity = targetPosition - thisPosition;
            newBullet.GetComponent<BulletMove>().setVelocity(velocity.normalized * speed);
            newBullet.GetComponent<BulletMove>().setDistance(radius);
        }
    }
}
