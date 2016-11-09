using System;

class EarnGold : Achievement
{
    public override void setData(int level)
    {
        this.level = level;
        type = Constants.AchievementTypes.earnGold;
        baseCost = 1000;
        costINC = 2;
        baseAward = 300;
        awardINC = 2;

        cost = (int)(baseCost * Math.Pow(costINC, level));
        award = (int)(baseAward * Math.Pow(awardINC, level));
        description = "Earn total " + cost + " gold!";

        if (PlayerDataUtil.playerData.totalEarnedGold >= cost)
        {
            earned = true;
        }
        else
        {
            earned = false;
        }
    }
}
