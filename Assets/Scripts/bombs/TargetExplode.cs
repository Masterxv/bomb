using UnityEngine;
using System.Linq;
using System.Collections;

public class TargetExplode : Explode
{
    public override void Start()
    {
        base.Start();
        numPoints = numPoints + PlayerDataUtil.playerData.shooterLevel * Constants.TARGET_BOMB_NUMPOINT_INC;
    }

    public override void DoExplode()
    {
        base.DoExplode();

        Vector3 thisPosition = transform.position;
        // Find targets
        GameObject [] allBomb = GameObject.FindGameObjectsWithTag("bomb");
        GameObject [] allBombSorted = allBomb.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();
        Destroy(gameObject); // Destroy this game object
        if (numPoints >= allBombSorted.Length)
        {
            numPoints = allBombSorted.Length - 1;
        }
        for (int pointNum = 1; pointNum < numPoints+1; pointNum++)
        {
            Vector3 targetPosition = allBombSorted[pointNum].transform.position;
            GameObject newBullet = Instantiate(bulletPrefab, thisPosition, Quaternion.identity) as GameObject;
            Vector3 velocity = (targetPosition - thisPosition).normalized*speed;
            float distance = Vector3.Distance(thisPosition, targetPosition);
            newBullet.GetComponent<Bullet>().setData(thisPosition, targetPosition, distance, velocity, bulletDamage, bulletHealth);
        }
    }
}
