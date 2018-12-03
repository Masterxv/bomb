using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{
    public bool isClockwise = true;
    public float speed;
    public float angleTraveled;

    public void SetRotateData(RotateData rotate)
    {
        isClockwise = rotate.isClockwise;
        speed = rotate.speed;
    }
    // Use this for initialization
    void Start()
    {
        angleTraveled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isClockwise)
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
        } else
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
        angleTraveled += speed * Time.deltaTime;
    }
}
