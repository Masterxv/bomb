using System;

class DestroyBomb : Achievement
{
    public override void setData(int level)
    {
        this.level = level;
        type = Constants.AchievementTypes.destroyBomb;
        baseCost = 10;
        costINC = 3;
        baseAward = 200;
        awardINC = 1.5f;

        cost = (int)(baseCost * Math.Pow(costINC, level));
        award = (int)(baseAward * Math.Pow(awardINC, level));
        description = "Explode total " + cost + " bombs!";
        progress = (int)(1.0f * PlayerDataUtil.playerData.totalBombExploded / cost * 100);
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
