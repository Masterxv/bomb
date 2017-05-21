using UnityEngine;

public class CoinFlyToMeter : MonoBehaviour
{
    public GameObject coinMeter;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GameController.Instance.coinMeter.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, coinMeter.transform.position, 1.8f * Time.deltaTime);
        if (Vector2.Distance(transform.position, coinMeter.transform.position) <= 1)
        {
            audioSource.Play();
            GameController.Instance.UpdateGold();
            Destroy(gameObject);
        }
    }
}
