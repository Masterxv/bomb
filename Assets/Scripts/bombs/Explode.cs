using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
    public GameObject bulletPrefab;

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

    public int valueInCoin;
    protected BaseBomb baseBomb;

    public virtual void setBombData(BombInfo bombInfo)
    {
        type = bombInfo.type;
        initPosition = new Vector3(bombInfo.x, bombInfo.y, bombInfo.z);
        initAngle = bombInfo.initAngle;
        switch(type)
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        DoExplode();
    }

    public virtual void DoExplode()
    {
        CoinUtil.CreateCoins(transform.position, valueInCoin);
    }
}
