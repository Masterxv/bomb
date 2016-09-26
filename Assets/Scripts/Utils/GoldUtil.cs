using System;
using System.Collections.Generic;

public class GoldUtil
{
    public static void AddGold(int valueInCoin)
    {
        PlayerDataUtil.playerData.gold += (int)(valueInCoin * (1 + PlayerDataUtil.playerData.goldLevel * Constants.GOLD_INC));
    }
}
