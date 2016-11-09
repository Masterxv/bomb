using System;

class DestroyBomb : Achievement
{
    public override void setData(int level)
    {
        this.level = level;
        baseCost = 10;
        costINC = 3;
        baseAward = 200;
        awardINC = 1.5f;

        cost = (int)(baseCost * Math.Pow(costINC, level));
        award = (int)(baseAward * Math.Pow(awardINC, level));
        description = "Explode total " + cost + " bombs!";
        if (PlayerDataUtil.playerData.totalBombExploded >= cost)
        {
            earned = true;
        }
        else
        {
            earned = false;
        }
    }
}
