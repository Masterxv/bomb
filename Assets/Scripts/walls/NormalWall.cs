using UnityEngine;
using System.Collections;

public class NormalWall : Wall {

    public override void CollisionWithBullet(GameObject bullet)
    {
        currentHealth -= 1;
        healthBar.sizeDelta = new Vector2(healthBar.sizeDelta.x, currentHealth * Constants.WALL_HEALTH_UNIT);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
