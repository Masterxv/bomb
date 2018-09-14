using UnityEngine;

public class CoinFlyToMeter : MonoBehaviour
{
    AudioSource audioSource;
    void Start()
    {
        audioSource = ControllerUtil.coreController.coinMeter.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject coinMeter = ControllerUtil.coreController.coinMeter;
        transform.position = Vector3.Lerp(transform.position, coinMeter.transform.position, 1.8f * Time.deltaTime);
        if (Vector2.Distance(transform.position, coinMeter.transform.position) <= 1)
        {
            audioSource.Play();
            ControllerUtil.coreController.UpdateGold();
            Destroy(gameObject);
        }
    }
}
