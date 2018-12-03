using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Explode : MonoBehaviour
{
    public GameObject bulletPrefab;
    public AudioClip bombExplodeSound;
    public GameObject locked;
    public TextMesh timer;

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
    public bool isLocked;
    public float timeout;

    public bool isExploded;
    public int valueInCoin;

    public float passedTime;
    private float intervalCounter;
    private const float PASSED_TIME_INTERVAL = 0.1f;

    public virtual void setBombData(BombInfo bombInfo)
    {
        type = bombInfo.type;
        initPosition = bombInfo.initPosition.GetV3();
        initAngle = bombInfo.initAngle;
        isLocked = bombInfo.isLocked;
        timeout = bombInfo.timeout;

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

        intervalCounter = 0;

        if(isLocked)
        {
            locked.SetActive(true);
        } else
        {
            locked.SetActive(false);
        }

        if(timeout > 0)
        {
            timer.gameObject.SetActive(true);
        } else
        {
            timer.gameObject.SetActive(false);
        }

        if (bombInfo.movement == null || bombInfo.movement.speed <= 0)
        {
            GetComponent<BombMovement>().enabled = false;
        }
        else
        {
            GetComponent<BombMovement>().enabled = true;
            GetComponent<BombMovement>().SetMovementData(bombInfo.movement);
        }

        if (bombInfo.rotate == null || bombInfo.rotate.speed <= 0)
        {
            GetComponent<BombRotate>().enabled = false;
        }
        else
        {
            GetComponent<BombRotate>().enabled = true;
            GetComponent<BombRotate>().SetRotateData(bombInfo.rotate);
        }
    }

    // Use this for initialization
    public virtual void Start()
    {
        currentHealth = health;
        baseBomb = null;
        isExploded = false;
        passedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeout <= 0)
        {
            return;
        }
        if (passedTime < timeout)
        {
            intervalCounter += Time.deltaTime;
            if (intervalCounter >= PASSED_TIME_INTERVAL) {
                passedTime += intervalCounter;
                timer.text = Math.Round(timeout - passedTime, 1) + ""; ;
                intervalCounter = 0;
            }
        } else
        {
            if(!isExploded)
            {
                timer.text = "";
                PrepareToExplode();
            }
        }
    }

    void OnMouseDown()
    {
        Debug.LogError("is locked" + isLocked);
        if (ControllerUtil.coreController.clickedNumber < ControllerUtil.coreController.numberOfClick && !isLocked)
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
