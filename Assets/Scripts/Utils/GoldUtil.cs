using System;
using System.Collections.Generic;

public class GoldUtil
{
    public static void AddGold(int valueInCoin)
    {
        int valueToAdd = (int)(valueInCoin * (1 + PlayerDataUtil.playerData.goldLevel * Constants.GOLD_INC));
        PlayerDataUtil.playerData.gold += valueToAdd;
        PlayerDataUtil.playerData.totalEarnedGold += valueToAdd;
    }
}
