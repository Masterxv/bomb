using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Explode : MonoBehaviour
{
    public GameObject bulletPrefab;
    protected BaseBomb baseBomb;

    public Constants.BombTypes type;
    public Vector3 initPosition;
    public float initAngle;

    public float radius;
    public float speed;
    public int numPoints;
    public int bulletDamage;
    public int bulletHealth;
    public int health;
    public int currentHealth;

    public bool isExploded;
    public AudioClip bombExplodeSound;
    public int valueInCoin;

    public virtual void setBombData(BombInfo bombInfo)
    {
        type = bombInfo.type;
        initPosition = bombInfo.initPosition.GetV3();
        initAngle = bombInfo.initAngle;

        switch (type)
        {
            case Constants.BombTypes.normal:
                baseBomb = new BaseNormalBomb();
                break;
            case Constants.BombTypes.shooter:
                baseBomb = new BaseShooterBomb();
                break;
            case Constants.BombTypes.target:
                baseBomb = new BaseTargetBomb();
                break;
            case Constants.BombTypes.wave:
                baseBomb = new BaseWaveBomb();
                break;
            case Constants.BombTypes.acid:
                baseBomb = new BaseAcidBomb();
                break;
        }
        radius = baseBomb.radius;
        speed = baseBomb.speed;
        numPoints = baseBomb.numPoints;
        bulletDamage = baseBomb.bulletDamage;
        bulletHealth = baseBomb.bulletHealth;
        health = baseBomb.health;
        currentHealth = baseBomb.currentHealth;
        valueInCoin = baseBomb.valueInCoin;
    }

    // Use this for initialization
    public virtual void Start()
    {
        currentHealth = health;
        baseBomb = null;
        isExploded = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (ControllerUtil.coreController.clickedNumber < ControllerUtil.coreController.numberOfClick)
        {
            ControllerUtil.coreController.UpdateClickedNumber();
            PrepareToExplode();
        }
    }

    public void PrepareToExplode()
    {
        ControllerUtil.coreController.isAnimating = true;
        isExploded = true;
        GetComponent<BombAnimation>().DoExplodeAnimation(DoExplode);
    }

    public virtual void DoExplode()
    {
        CoinUtil.CreateCoins(transform.position, valueInCoin);
        GoldUtil.AddGold(valueInCoin);
        if(bombExplodeSound != null)
        {
            AudioSource.PlayClipAtPoint(bombExplodeSound, transform.position);
        }
    }

    public virtual void DoneExplode()
    {
        ControllerUtil.coreController.isAnimating = false;
    }
}
