﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BombAcidAnimation: BombAnimation {

    public override void DoExplodeAnimation(TweenCallback callback)
    {
        transform.DOPunchScale(new Vector2(1.2f, 1.2f), 1).OnComplete(callback);
    }

    public override void DoStandingAnimation()
    {
        transform.DOScale(new Vector2(1.2f, 1.2f), 1).SetLoops(-1, LoopType.Yoyo);
    }
}
