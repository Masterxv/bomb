using UnityEngine;
using System.Collections;

public class CoinUtil : MySingleton<CoinUtil> {

    public GameObject coinPrefab;

    //public static GameObject coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");

    public void CreateCoin(Vector3 position)
    {
        Instantiate(coinPrefab, position, Quaternion.identity);
    }

    public void CreateCoins(Vector3 position, int numberOfCoin)
    {
        Vector3 coinPosition = new Vector3();
        for (int i=0; i<numberOfCoin; i++)
        {
            coinPosition.x = position.x + Random.Range(-2, 2);
            coinPosition.y = position.y + Random.Range(-2, 2);
            CreateCoin(coinPosition);
        }
    }
}
