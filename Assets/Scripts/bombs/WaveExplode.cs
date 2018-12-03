using UnityEngine;
using System.Collections;

public class WaveExplode : Explode
{
    public GameObject[] signs;
    public GameObject signPrefab;
    public float signRadius;
    public int waveWidth;
    private int bulletEachWave;
    private float diffAngleWavePoint;

    public override void setBombData(BombInfo bombInfo)
    {
        base.setBombData(bombInfo);
        signRadius = baseBomb.signRadius;
        waveWidth = baseBomb.waveWidth + LevelUtil.getCurrentLevel().waveLevel * Constants.WAVE_BOMB_WAVE_WIDTH_INC;
    }

    public override void Start()
    {
        base.Start();

        bulletEachWave = waveWidth * Constants.BULLET_WAVE_EACH_WIDTH;
        signs = new GameObject[numPoints];
        diffAngleWavePoint = 360 / numPoints;
        for (int pointNum = 0; pointNum < numPoints; pointNum++)
        {
            float tmpAngle = initAngle + (pointNum + 1) * diffAngleWavePoint;
            float x = Mathf.Sin(tmpAngle * Mathf.Deg2Rad) * signRadius;
            float y = Mathf.Cos(tmpAngle * Mathf.Deg2Rad) * signRadius;
            Vector3 targetPosition = new Vector3(x, y, 0) + transform.position;
            Quaternion rotation = Quaternion.AngleAxis(tmpAngle, new Vector3(0, 0, -1));
            GameObject tmpSign = Instantiate(signPrefab, targetPosition, rotation) as GameObject;
            tmpSign.transform.SetParent(gameObject.transform);
            signs[pointNum] = tmpSign;
        }
    }

    public override void DoExplode()
    {
        base.DoExplode();

        Vector3 thisPosition = transform.position;
        float angleTraveled = GetComponent<BombRotate>().angleTraveled;
        Destroy(gameObject); // Destroy this game object
        float currentAngle = initAngle + angleTraveled;
        Debug.LogError("current angle: " + currentAngle);
        float diffAngle = diffAngleWavePoint + 360 / Constants.BULLET_WAVE_DECREASE_ANGLE;

        for (int pointNum = 0; pointNum < signs.Length; pointNum++)
        {
            GameObject tmpSign = signs[pointNum];
        
            int from = (pointNum - 1)* bulletEachWave / 2;
            int to = pointNum * bulletEachWave / 2;

            for (int bulletCount = from; bulletCount < to ; bulletCount++)
            {
                float rotateAngle = (currentAngle + bulletCount * diffAngle) * Mathf.Deg2Rad;
                float x = Mathf.Sin(rotateAngle) * signRadius;
                float y = Mathf.Cos(rotateAngle) * signRadius;
                Vector3 targetPosition = new Vector3(x, y, 0) + transform.position;
                Vector3 velocity = (targetPosition - thisPosition).normalized * speed;

                GameObject newBullet = Instantiate(bulletPrefab, thisPosition, Quaternion.identity) as GameObject;
                newBullet.GetComponent<Bullet>().setData(thisPosition, targetPosition, Constants.BULLET_MAX_DISTANCE, velocity, bulletDamage, bulletHealth);
            }

            Destroy(tmpSign);
        }
        base.DoneExplode();
    }
}
