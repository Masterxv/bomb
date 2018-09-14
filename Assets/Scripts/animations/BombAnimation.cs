using UnityEngine;
using System.Collections;
using DG.Tweening;

public abstract class BombAnimation : MonoBehaviour
{
    void Start()
    {
        DoStandingAnimation();
    }

    abstract public void DoStandingAnimation();

    abstract public void DoExplodeAnimation(TweenCallback explode);
}
