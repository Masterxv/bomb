using UnityEngine;
using System.Collections;

public class AcidExplode : Explode {
    public float duration;

    public override void setBombData(BombInfo bombInfo)
    {
        base.setBombData(bombInfo);
        duration = baseBomb.duration * (1 + PlayerDataUtil.playerData.acidLevel * Constants.ACID_BOMB_DURATION_INC);
    }

    public override void DoExplode()
    {
        base.DoExplode();

        Vector3 thisPosition = transform.position;
        Destroy(gameObject); // Destroy this game object
        for(int i=0; i<3; i++)
        {
            for (int pointNum = 0; pointNum < numPoints/(1+i); pointNum++)
            {
                Vector3 targetPosition = new Vector2(thisPosition.x, thisPosition.y) + Random.insideUnitCircle * radius/(Mathf.Pow(2, i));
                GameObject newBullet = Instantiate(bulletPrefab, thisPosition, Quaternion.identity) as GameObject;
                Vector3 velocity = (targetPosition - thisPosition).normalized * speed;
                float distance = Vector3.Distance(thisPosition, targetPosition);
                newBullet.GetComponent<AcidBullet>().setData(thisPosition, targetPosition, distance, velocity, bulletDamage, bulletHealth, duration);
            }
        }
        base.DoneExplode();
    }
}
