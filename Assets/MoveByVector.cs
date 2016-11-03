using UnityEngine;
using System.Collections;

public class MoveByVector : MonoBehaviour {

    public Vector3 velocity;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody>().velocity = velocity;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
