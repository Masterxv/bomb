using UnityEngine;
using System.Collections;

public abstract class Wall : MonoBehaviour
{

    public Constants.WallTypes type;
    public int maxHealth;
    public int currentHealth;
    public float initAngle;
    public Vector3 initPosition;

    public AudioClip takeDamageSound;

    public virtual void Start()
    {

    }

    public virtual void setWallData(WallInfo wallInfo)
    {
        maxHealth = wallInfo.maxHealth;
        currentHealth = wallInfo.maxHealth >= wallInfo.currentHealth ? wallInfo.currentHealth : wallInfo.maxHealth;
        setHealthText();
        // rotate by init angle
        initAngle = wallInfo.initAngle;
        transform.Rotate(0, 0, -initAngle);
        initPosition = wallInfo.initPosition.GetV3();
        type = wallInfo.type;

        if (wallInfo.movement == null || wallInfo.movement.speed <= 0)
        {
            GetComponent<WallMovement>().enabled = false;
        }
        else
        {
            GetComponent<WallMovement>().enabled = true;
            GetComponent<WallMovement>().SetMovementData(wallInfo.movement);
        }

        if (wallInfo.rotate == null || wallInfo.rotate.speed <= 0)
        {
            GetComponent<WallRotate>().enabled = false;
        }
        else
        {
            GetComponent<WallRotate>().enabled = true;
            GetComponent<WallRotate>().SetRotateData(wallInfo.rotate);
        }
    }

    public abstract void setHealthText();

    public virtual void CollisionWithBullet(GameObject bullet)
    {
        // Play sound
        if (takeDamageSound != null)
        {
            AudioSource.PlayClipAtPoint(takeDamageSound, transform.position);
        }
    }
}
