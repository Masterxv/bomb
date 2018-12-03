using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    public List<Vector3> points = new List<Vector3>(4);
    public List<float> distances;

    public Constants.MovementTypes type;
    public float speed;

    [Header("For Circle move type only!")]
    public float radius;
    public float initAngle;
    public bool isClockwise = true;

    private int currentIndex;
    private int nextIndex;
    private int numPoints;
    private int turnTimes;

    private bool isProduction = false;

    public void SetMovementData(MovementData movement)
    {
        type = movement.type;
        points = new List<Vector3>();
        for (int i = 0; i < movement.points.Length; i++)
        {
            points.Add(movement.points[i].GetV3());
        }
        distances = movement.distances;
        type = movement.type;
        radius = movement.radius;
        speed = movement.speed;
        isClockwise = movement.isClockwise;
        initAngle = movement.initAngle * Mathf.Deg2Rad;
        isProduction = true;
    }

    // Use this for initialization
    void Start()
    {
        if (speed <= 0)
        {
            return;
        }
        turnTimes = 0;
        numPoints = points.Count;
        if (!isProduction)
        {
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
        if (type == Constants.MovementTypes.circle) // Move in a circle shape
        {
            if (isClockwise)
            {
                initAngle -= speed * Time.deltaTime;
            }
            else
            {
                initAngle += speed * Time.deltaTime;
            }
            float x = Mathf.Cos(initAngle) * radius + points[0].x;
            float y = Mathf.Sin(initAngle) * radius + points[0].y;
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
