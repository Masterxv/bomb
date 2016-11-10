using System;

class GetUpgrade : Achievement
{
    public override void setData(int level)
    {
        this.level = level;
        type = Constants.AchievementTypes.getUpgrade;
        baseCost = 10;
        costINC = 10;
        baseAward = 200;
        awardINC = 3;

        cost = (int)(baseCost + level * costINC);
        award = (int)(baseAward + level * awardINC);
        description = "Buy total " + cost + " upgrades!";

        progress = (int)(1.0f * PlayerDataUtil.playerData.totalUpgrade / cost * 100);
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
