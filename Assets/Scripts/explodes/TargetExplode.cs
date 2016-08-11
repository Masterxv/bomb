using UnityEngine;
using System.Linq;
using System.Collections;

public class TargetExplode : Explode
{
    public override void DoExplode()
    {
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
            Debug.Log(pointNum);
            Vector3 targetPosition = allBombSorted[pointNum].transform.position;
            GameObject newBullet = Instantiate(bullet, thisPosition, Quaternion.identity) as GameObject;
            newBullet.GetComponent<BulletMove>().setInitPosition(thisPosition);
            newBullet.GetComponent<BulletMove>().setTargetPosition(targetPosition);
            Vector3 velocity = targetPosition - thisPosition;
            newBullet.GetComponent<BulletMove>().setVelocity(velocity.normalized * speed);
            newBullet.GetComponent<BulletMove>().setDistance(Vector3.Distance(thisPosition, targetPosition));
        }
    }
}
