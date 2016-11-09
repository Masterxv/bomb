using System;

class PurchasePowerup : Achievement
{
    public override void setData(int level)
    {
        this.level = level;
        type = Constants.AchievementTypes.purchasePowerUp;
        baseCost = 10;
        costINC = 3;
        baseAward = 200;
        awardINC = 10;

        cost = (int)(baseCost + Math.Pow(costINC, level));
        award = (int)(baseAward + level * awardINC);
        description = "Purchase total " + cost + " Powerup!";

        if (PlayerDataUtil.playerData.totalPowerupPuchased >= cost)
        {
            earned = true;
        }
        else
        {
            earned = false;
        }
    }
}
