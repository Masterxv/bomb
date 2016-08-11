using UnityEngine;
using System.Collections;

public class ShooterExplode : Explode
{
    public GameObject sign;
    private GameObject[] signs;
    void Start()
    {
        signs = new GameObject [numPoints];
        float diffAngle = Mathf.PI / numPoints *2;
        for(int pointNum = 0; pointNum < numPoints; pointNum++)
        {
            float x = Mathf.Sin(initAngle + (pointNum+1) * diffAngle) * 3;
            float y = Mathf.Cos(initAngle + (pointNum+1) * diffAngle) * 3;
            Vector3 targetPosition = new Vector3(x, y, 0) + transform.position;
            GameObject tmpSign = Instantiate(sign, targetPosition, Quaternion.identity) as GameObject;
            signs[pointNum] = tmpSign;
        }
    }

    public override void DoExplode()
    {
        Vector3 thisPosition = transform.position;
        Destroy(gameObject); // Destroy this game object

        for (int pointNum = 0; pointNum < signs.Length; pointNum++)
        {
            GameObject tmpSign = signs[pointNum];
            Vector3 targetPosition = tmpSign.transform.position;

            GameObject newBullet = Instantiate(bullet, thisPosition, Quaternion.identity) as GameObject;
            newBullet.GetComponent<BulletMove>().setInitPosition(thisPosition);
            newBullet.GetComponent<BulletMove>().setTargetPosition(targetPosition);
            Vector3 velocity = targetPosition - thisPosition;
            newBullet.GetComponent<BulletMove>().setVelocity(velocity.normalized * speed);
            newBullet.GetComponent<BulletMove>().setDistance(radius);

            Destroy(tmpSign);
        }
    }
}
