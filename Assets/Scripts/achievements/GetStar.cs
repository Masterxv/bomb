using System;

class GetStar : Achievement
{
    public override void setData(int level)
    {
        this.level = level;
        type = Constants.AchievementTypes.getStar;
        baseCost = 20;
        costINC = 20;
        baseAward = 300;
        awardINC = 2;

        cost = (int)(baseCost + level * costINC);
        award = (int)(baseAward * Math.Pow(awardINC, level));
        description = "Win total " + cost + " stars!";

        if (PlayerDataUtil.playerData.earnedStars >= cost)
        {
            earned = true;
        }
        else
        {
            earned = false;
        }
    }
}
