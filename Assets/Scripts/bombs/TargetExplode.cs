using UnityEngine;
using System.Linq;
using System.Collections;

public class TargetExplode : Explode
{
    public GameObject[] signs;
    public GameObject signPrefab;
    public float signRadius;

    public override void Start()
    {
        base.Start();
        numPoints = numPoints + LevelUtil.getCurrentLevel().targetLevel * Constants.TARGET_BOMB_NUMPOINT_INC;
    }

    public override void DoExplode()
    {
        base.DoExplode();

        Vector3 thisPosition = transform.position;
        // Find targets
        GameObject [] allBomb = GameObject.FindGameObjectsWithTag("bomb");
        GameObject [] allBombSorted = allBomb.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();
        allBombSorted = allBombSorted.Skip(1).ToArray();
        Destroy(gameObject); // Destroy this game object
        if (numPoints > allBombSorted.Length)
        {
            numPoints = allBombSorted.Length;
        }
        for (int pointNum = 0; pointNum < numPoints; pointNum++)
        {
            Vector3 targetPosition = allBombSorted[pointNum].transform.position;
            GameObject newBullet = Instantiate(bulletPrefab, thisPosition, Quaternion.identity) as GameObject;
            Vector3 velocity = (targetPosition - thisPosition).normalized*speed;
            newBullet.GetComponent<Bullet>().setData(thisPosition, targetPosition, Constants.BULLET_MAX_DISTANCE, velocity, bulletDamage, bulletHealth);
        }
        base.DoneExplode();
    }
}
