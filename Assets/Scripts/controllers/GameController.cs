using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{

    public GameObject normalBomb;
    public GameObject shooterBomb;
    public GameObject targetBomb;
    public GameObject waveBomb;
    public GameObject acidBomb;
    
    public GameObject resultPanel;

    public string levelIndex;
    public static int clickedNumber;

    // Use this for initialization
    void Start()
    {
        PlayerDataUtil.SavePlayerDataFirstTime();
        PlayerDataUtil.LoadPlayerData(); // TODO: remove in production
        Level level = LevelUtil.getCurrentLevel();
        // Init all bombs in level
        for (int i = 0; i < level.bombs.Count; i++)
        {
            BombInfo bombInfo = level.bombs[i];
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
            if(bombInfo.movement == null)
            {
                bomb.GetComponent<BombMovement>().enabled = false;
            } else
            {
                bomb.GetComponent<BombMovement>().SetMovementData(bombInfo.movement);
            }
        }

        // Init tutorials
        if (level.tutorialContent == "")
        {
            GameObject.Find("Tutorial").SetActive(false);
        }
        else
        {
            GameObject.Find("Tutorial").GetComponentInChildren<Text>().text = level.tutorialContent;
            GameObject.Find("Tutorial").GetComponentsInChildren<Image>()[1].sprite = Resources.Load<Sprite>("Sprites/tutorials/" + level.tutorialImage);
        }

        UpdateGold();
    }

    public static void UpdateGold()
    {
        GameObject.Find("CoinMeterCount").GetComponent<TextMesh>().text = PlayerDataUtil.playerData.gold.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(clickedNumber >= LevelUtil.getCurrentLevel().numberOfClick && GameObject.FindGameObjectsWithTag("bullet").Length <= 0)
        {
            // End this level, show the result
            resultPanel.SetActive(true);
            int stars = GetStars();
            Sprite starSprite = Resources.Load<Sprite>("Sprites/stars/star");
            switch (stars)
            {
                case 1:
                    GameObject.Find("Star1").GetComponent<Image>().sprite = starSprite;
                    break;
                case 2:
                    GameObject.Find("Star1").GetComponent<Image>().sprite = starSprite;
                    GameObject.Find("Star2").GetComponent<Image>().sprite = starSprite;
                    break;
                case 3:
                    GameObject.Find("Star1").GetComponent<Image>().sprite = starSprite;
                    GameObject.Find("Star2").GetComponent<Image>().sprite = starSprite;
                    GameObject.Find("Star3").GetComponent<Image>().sprite = starSprite;
                    break;
            }
        }
    }

    public static int GetStars()
    {
        int remainBombs = GameObject.FindGameObjectsWithTag("bomb").Length;
        if (remainBombs <= Constants.BOMB_REMAIN_3_STAR_THRESHOLD)
        {
            return 3;
        } else if (remainBombs <= Constants.BOMB_REMAIN_2_STAR_THRESHOLD)
        {
            return 2;
        } else if (remainBombs <= Constants.BOMB_REMAIN_1_STAR_THRESHOLD)
        {
            return 1;
        }
        return 0;
    }
}
