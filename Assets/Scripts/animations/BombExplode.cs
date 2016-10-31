using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BombExplode : MonoBehaviour {
    public GameObject bomb;

	void Start () {
        transform.DOPunchScale(new Vector2(1.2f, 1.2f), 1);
    }
}
