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
        awardINC = 500;

        cost = (int)(baseCost + level * costINC);
        award = (int)(baseAward + level * awardINC);
        description = "Buy total " + cost + " upgrades!";

        if (PlayerDataUtil.playerData.totalUpgrade >= cost)
        {
            earned = true;
        }
        else
        {
            earned = false;
        }
    }
}
