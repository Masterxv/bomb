using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    private Vector3 initPosition;
    private Vector3 targetPosition;
    private Vector3 velocity;
    private Rigidbody2D rb;
    private float distance;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = velocity;
    }

	void Update () {
        if (Vector3.Distance(transform.position, initPosition) > distance)
        {
            rb.velocity = new Vector3(0, 0, 0);
            Destroy(gameObject);
        }
    }

    public void setInitPosition(Vector3 initPosition)
    {
        this.initPosition = initPosition;
    }

    public void setTargetPosition(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }

    public void setVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }
    
    public void setDistance(float distance)
    {
        this.distance = distance;
    }
}
