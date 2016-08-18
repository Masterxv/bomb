using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject normalBomb;
    public GameObject shooterBomb;
    public GameObject targetBomb;
    public GameObject waveBomb;

    enum BombTypes { normal, shooter, target, wave };

	// Use this for initialization
	void Start () {
        Level level = LevelUtil.getCurrentLevel();
        // Init all bombs in level
        for (int i=0; i<level.bombs.Count; i++)
        {
            BombInfo bombInfo = level.bombs[i];
            GameObject bomb = null;
            switch(bombInfo.type)
            {
                case (int)BombTypes.normal:
                    bomb = Instantiate(normalBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
                    break;
                case (int)BombTypes.shooter:
                    bomb = Instantiate(shooterBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
                    break;
                case (int)BombTypes.target:
                    bomb = Instantiate(targetBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
                    break;
                case (int)BombTypes.wave:
                    bomb = Instantiate(waveBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
                    break;
            }
            if (bomb == null)
            {
                bomb = Instantiate(normalBomb, bombInfo.initPosition, Quaternion.identity) as GameObject;
            }
            bomb.GetComponent<Explode>().setBombData(bombInfo);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
