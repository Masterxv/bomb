using UnityEngine;
using System.Collections;

public class Constants
{
    public static float BULLET_MAX_DISTANCE = 100;
    public static int BULLET_WAVE_EACH_WIDTH = 4;
    public static int BULLET_WAVE_DECREASE_ANGLE = 150;

    public static int LEVEL_MARGIN = 15;
    public static int TOTAL_LEVEL = 42;

    public static int NORMAL_BOMB_UPGRADE_BASE_COST = 1;
    public static int SHOOTER_BOMB_UPGRADE_BASE_COST = 2;
    public static int TARGET_BOMB_UPGRADE_BASE_COST = 3;
    public static int WAVE_BOMB_UPGRADE_BASE_COST = 2;

    public static int BOMB_UPGRADE_MAX_LEVEL = 4;
    public static int GOLd_UPGRADE_MAX_LEVEL = 7;

    public enum BombTypes { normal, shooter,  target, wave };
}
