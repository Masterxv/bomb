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
        awardINC = 4;

        cost = (int)(baseCost + Math.Pow(costINC, level));
        award = (int)(baseAward + Math.Pow(awardINC, level));
        description = "Purchase total " + cost + " Powerup!";

        progress = (int)(1.0f * PlayerDataUtil.playerData.totalPowerupPuchased / cost * 100);
        if (progress >= 100)
        {
            earned = true;
        }
        else
        {
            earned = false;
        }
    }
}
