using UnityEngine;
using System.Collections;

public class BombRotate : MonoBehaviour
{
    public bool isClockwise = true;
    public float speed;

    public void SetRotateData(BombRotateData rotate)
    {
        isClockwise = rotate.isClockwise;
        speed = rotate.speed;
    }
    // Use this for initialization
    void Start()
    {

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
        
    }
}
