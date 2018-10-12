using System;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MySingleton<BombManager>
{
    // Bomb
    public GameObject normalBomb;
    public GameObject shooterBomb;
    public GameObject targetBomb;
    public GameObject waveBomb;
    public GameObject acidBomb;

    public void CreateBomb(BombInfo bombInfo)
    {
        GameObject bomb = null;
        switch (bombInfo.type)
        {
            case Constants.BombTypes.normal:
                bomb = Instantiate(normalBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                break;
            case Constants.BombTypes.shooter:
                bomb = Instantiate(shooterBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                break;
            case Constants.BombTypes.target:
                bomb = Instantiate(targetBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                break;
            case Constants.BombTypes.wave:
                bomb = Instantiate(waveBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                break;
            case Constants.BombTypes.acid:
                bomb = Instantiate(acidBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                break;
        }
        if (bomb == null)
        {
            bomb = Instantiate(normalBomb, bombInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
        }
        bomb.GetComponent<Explode>().setBombData(bombInfo);
    }
}
