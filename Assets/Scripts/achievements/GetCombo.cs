using System;

class GetCombo : Achievement
{
    public override void setData(int level)
    {
        this.level = level;
        type = Constants.AchievementTypes.getCombo;
        baseCost = 20;
        costINC = 10;
        baseAward = 200;
        awardINC = 2;

        cost = (int)(baseCost + level*costINC);
        award = (int)(baseAward * Math.Pow(awardINC, level));
        description = "Get a combo " + cost + " bombs!";

        if (PlayerDataUtil.playerData.bestCombo >= cost)
        {
            earned = true;
        }
        else
        {
            earned = false;
        }
    }
}
