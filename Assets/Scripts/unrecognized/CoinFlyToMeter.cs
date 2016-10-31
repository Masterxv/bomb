using UnityEngine;
using System.Collections;

public class CoinFlyToMeter : MonoBehaviour {
    public GameObject coinMeter;

	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, coinMeter.transform.position, 1.8f*Time.deltaTime);
        if(Vector2.Distance(transform.position, coinMeter.transform.position) <= 1)
        {
            Destroy(gameObject);
            GameController.instance.UpdateGold();
        }
    }
}
