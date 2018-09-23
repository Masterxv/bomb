using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NormalWall : Wall {

    Text healthText;
    public override void CollisionWithBullet(GameObject bullet)
    {
        currentHealth -= 1;
        healthText.text = currentHealth + string.Empty;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public override void setHealthText()
    {
        healthText = GetComponentInChildren<Text>();
        healthText.text = currentHealth + string.Empty;
    }
}
