﻿using UnityEngine;
using System.Collections;

public class Constants
{
    public static float BULLET_MAX_DISTANCE = 100;
    public static int BULLET_WAVE_EACH_WIDTH = 4;
    public static int BULLET_WAVE_DECREASE_ANGLE = 150;
    public static int LEVEL_MARGIN = 15;
    public static int TOTAL_LEVEL = 42;

    public enum BombTypes { normal, shooter,  target, wave };
}
