using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BombStanding : MonoBehaviour {
	void Start () {
        transform.DOScale(new Vector2(1.2f, 1.2f), 1).SetLoops(-1, LoopType.Yoyo);
    }
}
