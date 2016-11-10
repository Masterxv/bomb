﻿using UnityEngine;
using System.Collections;

public class Constants
{
    // Main game scene
    public static float BULLET_MAX_DISTANCE = 100; // Meter in game
    public static int BULLET_WAVE_EACH_WIDTH = 4; // Meter in game
    public static int BULLET_WAVE_DECREASE_ANGLE = 150; // Degree

    public static int NORMAL_BOMB_BASE_VALUE = 10; // Gold
    public static int SHOOTER_BOMB_BASE_VALUE = 20; // Gold
    public static int TARGET_BOMB_BASE_VALUE = 30; // Gold
    public static int WAVE_BOMB_BASE_VALUE = 20; // Gold

    public static int BOMB_REMAIN_1_STAR_THRESHOLD = 10; // Bomb
    public static int BOMB_REMAIN_2_STAR_THRESHOLD = 3; // Bomb
    public static int BOMB_REMAIN_3_STAR_THRESHOLD = 0; // Bomb

    public enum BombTypes { normal, shooter, target, wave, acid };
    public enum WallTypes { normal, contrary};
    public enum MovementTypes { polyline, polygon, circle };
    public enum AchievementTypes { destroyBomb, earnGold, getCombo, getStar, getUpgrade, purchasePowerUp};

    // Level selection scene
    public static int LEVEL_MARGIN = 0;
    public static int TOTAL_LEVEL = 42;

    // Upgrade
    public static int NORMAL_BOMB_UPGRADE_BASE_COST = 1; // Star
    public static int SHOOTER_BOMB_UPGRADE_BASE_COST = 2; // Star
    public static int TARGET_BOMB_UPGRADE_BASE_COST = 3; // Star
    public static int WAVE_BOMB_UPGRADE_BASE_COST = 2; // Star
    public static int GOLD_UPGRADE_BASE_COST = 3; // Star
    public static int RESET_STARS_BASE_COST = 1000; // Gold
    public static int UPGRADE_MAX_LEVEL = 10;

    // Upgrade increment
    public static float NORMAL_BOMB_RADIUS_INC = 0.1f; // 10%
    public static int SHOOTER_BOMB_NUMPOINT_INC = 1; // target
    public static int TARGET_BOMB_NUMPOINT_INC = 1; // target
    public static int WAVE_BOMB_WAVE_WIDTH_INC = 1; // 100/3 %
    public static int ACID_BOMB_DURATION_INC = 1; // second
    public static float BOMB_VALUE_INC = 0.1f; // 10% 
    public static float GOLD_INC = 0.1f; // 10%

    // Achievement award in gold
    public static int ACHIEVEMENT_MAX_LEVEL = 10;

    // Shop - powerup
    public static int MORE_BOMB = 1000; // Gold
    public static int ONE_MORE_CLICK = 1000; // Gold

    // Shop - in-app purchase
    public static int PAKE_10000_GOLD = 1; // USD
    public static int PAKE_60000_GOLD = 5; // USD
    public static int PAKE_200000_GOLD = 15; // USD

    // Health bar unit
    public static int WALL_HEALTH_UNIT = 50; // meter

    // Match count for show ads
    public static int MATCH_COUNT_EACH_POPUP_ADS = 5;
}
