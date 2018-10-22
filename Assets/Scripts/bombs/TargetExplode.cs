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
        Debug.LogError("num points: " + numPoints);
        signs = new GameObject[numPoints];
        //for (int pointNum = 0; pointNum < numPoints; pointNum++)
        //{
        //    float tmpAngle = initAngle + (pointNum + 1) * diffAngle;
        //    float x = Mathf.Sin(tmpAngle * Mathf.Deg2Rad) * signRadius;
        //    float y = Mathf.Cos(tmpAngle * Mathf.Deg2Rad) * signRadius;
        //    Vector3 targetPosition = new Vector3(x, y, 0) + transform.position;
        //    Quaternion rotation = Quaternion.AngleAxis(tmpAngle, new Vector3(0, 0, -1));
        //    GameObject tmpSign = Instantiate(signPrefab, targetPosition, rotation) as GameObject;
        //    tmpSign.transform.SetParent(gameObject.transform);
        //    signs[pointNum] = tmpSign;
        //}

        GameObject[] allBomb = GameObject.FindGameObjectsWithTag("bomb");
        GameObject[] allBombSorted = allBomb.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();
        allBombSorted = allBombSorted.Skip(1).ToArray();
        if (numPoints > allBombSorted.Length)
        {
            numPoints = allBombSorted.Length;
        }
        for (int pointNum = 0; pointNum < numPoints; pointNum++)
        {
            Vector3 otherBombTargetPosition = allBombSorted[pointNum].transform.position;
            float diffAngle = Vector3.Angle(transform.position, otherBombTargetPosition);
            Debug.LogError("diff angle: " + diffAngle);
            float tmpAngle = (pointNum) * diffAngle;
            float x = Mathf.Sin(tmpAngle * Mathf.Deg2Rad) * signRadius;
            float y = Mathf.Cos(tmpAngle * Mathf.Deg2Rad) * signRadius;
            Vector3 targetPosition = new Vector3(x, y, 0) + transform.position;
            Quaternion rotation = Quaternion.AngleAxis(tmpAngle, new Vector3(0, 0, -1));
            GameObject tmpSign = Instantiate(signPrefab, targetPosition, rotation) as GameObject;
            tmpSign.transform.SetParent(gameObject.transform);
            signs[pointNum] = tmpSign;
        }
    }

    public void Update()
    {
        GameObject[] allBomb = GameObject.FindGameObjectsWithTag("bomb");
        GameObject[] allBombSorted = allBomb.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).ToArray();
        allBombSorted = allBombSorted.Skip(1).ToArray();
        if (numPoints > allBombSorted.Length)
        {
            numPoints = allBombSorted.Length;
        }
        for (int pointNum = 0; pointNum < numPoints; pointNum++)
        {
            Vector3 otherBombTargetPosition = allBombSorted[pointNum].transform.position;
            float diffAngle = Vector3.Angle(transform.position, otherBombTargetPosition);
            Debug.LogError("diff angle: " + diffAngle);
            float tmpAngle = (pointNum) * diffAngle;
            float x = Mathf.Sin(tmpAngle * Mathf.Deg2Rad) * signRadius;
            float y = Mathf.Cos(tmpAngle * Mathf.Deg2Rad) * signRadius;
            Vector3 targetPosition = new Vector3(x, y, 0) + transform.position;
            Quaternion rotation = Quaternion.AngleAxis(tmpAngle, new Vector3(0, 0, -1));
            //GameObject tmpSign = Instantiate(signPrefab, targetPosition, rotation) as GameObject;
            //tmpSign.transform.SetParent(gameObject.transform);
            signs[pointNum].transform.position = targetPosition;
            signs[pointNum].transform.rotation = rotation;
        }
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
            float distance = Vector3.Distance(thisPosition, targetPosition);
            newBullet.GetComponent<Bullet>().setData(thisPosition, targetPosition, distance, velocity, bulletDamage, bulletHealth);
        }
        base.DoneExplode();
    }
}
