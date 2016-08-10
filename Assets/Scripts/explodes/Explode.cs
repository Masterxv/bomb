using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour{
    public float radius;
    public GameObject bullet;
    public float speed;
    public int numPoints;

    // Use this for initialization
    void Start()
    {
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

    }
}
