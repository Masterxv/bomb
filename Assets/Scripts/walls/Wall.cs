using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    public Constants.WallTypes type;
    public int maxHealth;
    public int currentHealth;
    public float initAngle;
    public Vector3 initPosition;

    public AudioClip takeDamageSound;
    public RectTransform healthBar;

    public virtual void setWallData(WallInfo wallInfo)
    {
        maxHealth = wallInfo.maxHealth;
        currentHealth = wallInfo.currentHealth;
        initAngle = wallInfo.initAngle;
        initPosition = wallInfo.initPosition.GetV3();
        type = wallInfo.type;
    }

    public virtual void TakeDamage()
    {
        // Play sound
        if (takeDamageSound != null)
        {
            AudioSource.PlayClipAtPoint(takeDamageSound, transform.position);
        }
        // Update health bar
        Debug.Log(currentHealth);
        currentHealth -= 1;
        healthBar.sizeDelta = new Vector2(healthBar.sizeDelta.x, currentHealth*Constants.WALL_HEALTH_UNIT);
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
