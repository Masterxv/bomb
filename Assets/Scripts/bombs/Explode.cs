using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

    public int valueInCoin;

    // movement
    // 4 points to design level
    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;
    public Vector3 point4;
    public BombMovementData movement;
    public List<Vector3> movementPoints;
    public List<float> movementDistances;
    public float movementRadius;
    public float movementSpeed;
    public bool movementIsLoop;

    private int movementCurrentIndex;
    private int movementNextIndex;
    private int movementNumPoints;
    private int movementTurnTime;

    public virtual void setBombData(BombInfo bombInfo)
    {
        type = bombInfo.type;
        initPosition = bombInfo.initPosition.GetV3();
        initAngle = bombInfo.initAngle;
        movement = bombInfo.movement;


        //// Init movement parameter
        if (movement != null)
        {
            movementNumPoints = bombInfo.movement.points.Length;
            movementPoints = new List<Vector3>();
            for (int i = 0; i < movementNumPoints; i++)
            {
                movementPoints.Add(bombInfo.movement.points[i].GetV3());
            }
            movementDistances = bombInfo.movement.distances;
            movementSpeed = bombInfo.movement.speed;
            movementRadius = bombInfo.movement.radius;
            movementIsLoop = bombInfo.movement.isLoop;
        }

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
        movementTurnTime = 0;
        if (point1.x != 0)
        {
            movementPoints.Add(point1);
        }
        if (point2.x != 0)
        {
            movementPoints.Add(point2);
        }
        if (point3.x != 0)
        {
            movementPoints.Add(point3);
        }
        if (point4.x != 0)
        {
            movementPoints.Add(point4);
        }

        movementNumPoints = movementPoints.Count;
        for (int i = 0; i < movementNumPoints - 1; i++)
        {
            movementDistances.Add(Vector3.Distance(movementPoints[i], movementPoints[i + 1]));
        }
        if (movementIsLoop)
        {
            movementDistances.Add(Vector3.Distance(movementPoints[movementNumPoints - 1], movementPoints[0]));
        }

        transform.position = point1;
        movementCurrentIndex = 0;
        movementNextIndex = 1;
    }

    public float movementAngle = 0;
    // Update is called once per frame
    void Update()
    {
        if (movementSpeed > 0)
        {
            if (movementRadius > 0) // Move in a circle shape
            {
                movementAngle += movementSpeed * Time.deltaTime;
                float x = Mathf.Cos(movementAngle) * movementRadius + movementPoints[0].x;
                float y = Mathf.Sin(movementAngle) * movementRadius + movementPoints[0].y;
                transform.position = new Vector3(x, y, 0);
            }
            else // Move in a polyline or polygon
            {
                float distance = Vector3.Distance(transform.position, movementPoints[movementCurrentIndex]);
                bool checkDistance = distance >= movementDistances[movementCurrentIndex];
                if (checkDistance)
                {
                    if (movementIsLoop) // Move in a polygon
                    {
                        movementCurrentIndex = movementTurnTime % movementNumPoints;
                        movementNextIndex = movementCurrentIndex + 1;
                        if (movementNextIndex >= movementNumPoints)
                        {
                            movementNextIndex = 0;
                        }
                        movementTurnTime++;
                    }
                    else // Move in a polyline
                    {
                        if (movementNextIndex >= movementNumPoints - 1)
                        {
                            movementPoints.Reverse();
                            movementDistances.Reverse();
                            movementCurrentIndex = 0;
                            movementNextIndex = 1;
                        }
                        else
                        {
                            movementCurrentIndex++;
                            movementNextIndex++;
                        }
                    }
                }

                float step = movementSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, movementPoints[movementNextIndex], step);
            }
        }
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
