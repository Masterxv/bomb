using UnityEngine;
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

    public enum BombTypes { normal, shooter, target, wave, acid };
    public enum MovementTypes { polyline, polygon, circle };

    // Level selection scene
    public static int LEVEL_MARGIN = 15;
    public static int TOTAL_LEVEL = 42;

    // Upgrade
    public static int NORMAL_BOMB_UPGRADE_BASE_COST = 1; // Star
    public static int SHOOTER_BOMB_UPGRADE_BASE_COST = 2; // Star
    public static int TARGET_BOMB_UPGRADE_BASE_COST = 3; // Star
    public static int WAVE_BOMB_UPGRADE_BASE_COST = 2; // Star
    public static int GOLD_UPGRADE_BASE_COST = 3; // Star

    public static int BOMB_UPGRADE_MAX_LEVEL = 4;
    public static int GOLD_UPGRADE_MAX_LEVEL = 7;

    public static int RESET_STARS_BASE_COST = 1000; // Gold

    // Shop - bomb
    public static int NORMAL_BOMB_PRICE = 1000; // Gold
    public static int SHOOTER_BOMB_PRICE = 2000; // Gold
    public static int TARGET_BOMB_PRICE = 3000; // Gold
    public static int WAVE_BOMB_PRICE = 2000; // Gold

    // Shop - powerup
    public static int MORE_BOMB = 1000; // Gold
    public static int ONE_MORE_CLICK = 1000; // Gold

    // Shop - in-app purchase
    public static int PAKE_1000_GOLD = 5; // USD
    public static int PAKE_3000_GOLD = 10; // USD
    public static int PAKE_10000_GOLD = 15; // USD
}
