using UnityEngine;

public class CoinFlyToMeter : MonoBehaviour
{
    public float speed;
    AudioSource audioSource;
    Vector3 coinMeterPosition;
    void Start()
    {
        speed = Random.Range(12, 20);
        Vector3 worldPoint = ControllerUtil.coreController.coinMeter.transform.position;
        coinMeterPosition = Camera.main.ScreenToWorldPoint(worldPoint);
        audioSource = ControllerUtil.coreController.coinMeter.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, coinMeterPosition, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, coinMeterPosition) <= 0.3)
        {
            audioSource.Play();
            GoldUtil.AddGold(1);
            ControllerUtil.coreController.UpdateGold();
            Destroy(gameObject);
        }
    }
}
