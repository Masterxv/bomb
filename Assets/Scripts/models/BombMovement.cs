using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombMovement : MonoBehaviour
{
    private float movementAngle;

    public Vector3 point1;
    public Vector3 point2;
    public Vector3 point3;
    public Vector3 point4;

    public List<Vector3> points;
    public List<float> distances;

    public Constants.MovementTypes type;
    public float radius;
    public float speed;
    public bool isClockwise;

    private int currentIndex;
    private int nextIndex;
    private int numPoints;
    private int turnTimes;

    private bool isProduction = false;

    public void SetMovementData(BombMovementData movement)
    {
        if (movement == null)
        {
            speed = -1;
            return;
        }
        type = movement.type;
        for (int i = 0; i < movement.points.Length; i++)
        {
            points.Add(movement.points[i].GetV3());
        }
        distances = movement.distances;
        type = movement.type;
        radius = movement.radius;
        speed = movement.speed;
        isClockwise = movement.isClockwise;
        isProduction = true;
    }

    // Use this for initialization
    void Start()
    {
        turnTimes = 0;
        numPoints = points.Count;

        if (!isProduction)
        {
            if (point1.x != -1)
            {
                points.Add(point1);
            }
            if (point2.x != -1)
            {
                points.Add(point2);
            }
            if (point3.x != -1)
            {
                points.Add(point3);
            }
            if (point4.x != -1)
            {
                points.Add(point4);
            }

            numPoints = points.Count;
       
            for (int i = 0; i < numPoints - 1; i++)
            {
                distances.Add(Vector3.Distance(points[i], points[i + 1]));
            }
            if (type == Constants.MovementTypes.polygon)
            {
                distances.Add(Vector3.Distance(points[numPoints - 1], points[0]));
            }
        }

        transform.position = points[0];
        currentIndex = 0;
        nextIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed <= 0)
        {
            return;
        }
        if (type == Constants.MovementTypes.circle) // Move in a circle shape
        {
            if (isClockwise)
            {
                movementAngle += speed * Time.deltaTime;
            }
            else
            {
                movementAngle -= speed * Time.deltaTime;
            }
            float x = Mathf.Cos(movementAngle) * radius + points[0].x;
            float y = Mathf.Sin(movementAngle) * radius + points[0].y;
            transform.position = new Vector3(x, y, 0);
        }
        else // Move in a polyline or polygon
        {
            float distance = Vector3.Distance(transform.position, points[currentIndex]);
            bool checkDistance = distance >= distances[currentIndex];
            if (checkDistance)
            {
                if (type == Constants.MovementTypes.polygon) // Move in a polygon
                {
                    currentIndex = turnTimes % numPoints;
                    nextIndex = currentIndex + 1;
                    if (nextIndex >= numPoints)
                    {
                        nextIndex = 0;
                    }
                    turnTimes++;
                }
                else // Move in a polyline
                {
                    if (nextIndex >= numPoints - 1)
                    {
                        points.Reverse();
                        distances.Reverse();
                        currentIndex = 0;
                        nextIndex = 1;
                    }
                    else
                    {
                        currentIndex++;
                        nextIndex++;
                    }
                }
            }

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, points[nextIndex], step);
        }
    }
}
