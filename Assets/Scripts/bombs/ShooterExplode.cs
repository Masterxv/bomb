using UnityEngine;
using System.Collections;

public class ShooterExplode : Explode
{
    public GameObject[] signs;
    public GameObject signPrefab;
    public int signRadius;

    public override void setBombData(BombInfo bombInfo)
    {
        base.setBombData(bombInfo);
        signRadius = baseBomb.signRadius;
    }

    public override void Start()
    {
        base.Start();

        numPoints = numPoints + PlayerDataUtil.playerData.shooterLevel * Constants.SHOOTER_BOMB_NUMPOINT_INC;
        signs = new GameObject [numPoints];
        float diffAngle = 360 / numPoints;
        for(int pointNum = 0; pointNum < numPoints; pointNum++)
        {
            float x = Mathf.Sin((initAngle + (pointNum+1) * diffAngle)*Mathf.Deg2Rad) * signRadius;
            float y = Mathf.Cos((initAngle + (pointNum+1) * diffAngle)*Mathf.Deg2Rad) * signRadius;
            Vector3 targetPosition = new Vector3(x, y, 0) + transform.position;
            // float tmpAngle = initAngle + (pointNum + 1) * diffAngle;
            // Quaternion rotation = Quaternion.AngleAxis(tmpAngle, new Vector3(0, 0, 1));
            GameObject tmpSign = Instantiate(signPrefab, targetPosition, Quaternion.identity) as GameObject;
            tmpSign.transform.SetParent(gameObject.transform);
            signs[pointNum] = tmpSign;
        }
    }

    public override void DoExplode()
    {
        base.DoExplode();

        Vector3 thisPosition = transform.position;
        Destroy(gameObject); // Destroy this game object

        for (int pointNum = 0; pointNum < signs.Length; pointNum++)
        {
            GameObject tmpSign = signs[pointNum];
            Vector3 targetPosition = tmpSign.transform.position;

            GameObject newBullet = Instantiate(bulletPrefab, thisPosition, Quaternion.identity) as GameObject;
            Vector3 velocity = (targetPosition - thisPosition).normalized* speed;
            newBullet.GetComponent<Bullet>().setData(thisPosition, targetPosition, Constants.BULLET_MAX_DISTANCE, velocity, bulletDamage, bulletHealth);
            Destroy(tmpSign);
        }
    }
}
