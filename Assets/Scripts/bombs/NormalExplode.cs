using UnityEngine;
using System.Collections;

public class NormalExplode : Explode
{
    public NormalExplode(Vector3 initPosition, float radius, float speed, int numPoints, float initAngle, int bulletDamage, int bulletHealth, int health, int currentHealth, int signRadius) : base(initPosition,  radius,  speed,  numPoints,  initAngle,  bulletDamage,  bulletHealth,  health,  currentHealth,  signRadius)
    {

    }

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

            GameObject newBullet = Instantiate(bulletPrefab, thisPosition, Quaternion.identity) as GameObject;
            Vector3 velocity = (targetPosition - thisPosition).normalized*speed;
            newBullet.GetComponent<Bullet>().setData(thisPosition, targetPosition, radius, velocity, bulletDamage, bulletHealth);
        }
    }
}
