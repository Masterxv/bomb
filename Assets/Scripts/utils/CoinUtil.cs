using UnityEngine;
using System.Collections;

public class CoinUtil : MonoBehaviour {
    public static GameObject coinPrefab = Resources.Load<GameObject>("Prefabs/Coin");

    public static void CreateCoin(Vector3 position)
    {
        GameObject newCoin = Instantiate(coinPrefab, position, Quaternion.identity) as GameObject;
    }

    public static void CreateCoins(Vector3 position, int numberOfCoin)
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
