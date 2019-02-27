﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis
{
    //PlayerMovement
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
}

public class MouseAxis
{
    //MoveLook
    public const string MOUSE_X = "Mouse X";
    public const string MOUSE_Y = "Mouse Y";
}

public class AnimationTags
{

    //PlayerAttack
    public const string ZOOM_IN_ANIM = "Zoom In";
    public const string ZOOM_OUT_ANIM = "Zoom Out";
    public const string SHOOT_TRIGGER = "Shoot";
    public const string AIM_PARAMETER = "Aim";

    //Enemy
    public const string WALK_PARAMETER = "Walk";
    public const string RUN_PARAMETER = "Run";
    public const string ATTACK_TRIGGER = "Attack";
    public const string DEAD_TRIGGER = "Dead";

}

public class Tags
{

    public const string LOOK_ROOT = "Look Root";
    public const string ZOOM_CAMERA = "FP Camera";
    public const string CROSSHAIR = "Crosshair";
    public const string ARROW_TAG = "Arrow";

    public const string AXE_TAG = "Axe";

    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";

}