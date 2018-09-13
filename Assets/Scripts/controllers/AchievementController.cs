using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementController : MonoBehaviour {

    public GameObject destroyBombPrefab;
    public GameObject earnGoldPrefab;
    public GameObject getStarPrefab;
    public GameObject getUpgradePrefab;
    public GameObject getComboPrefab;
    public GameObject purchasePowerupPrefab;

    public GameObject achievementInfoPanel;

    public GameObject currentGold;
    public GameObject currentEarnedStar;

    static AchievementController _instance;
    public static AchievementController instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
        PlayerDataUtil.SavePlayerDataFirstTime(); // TODO: remove in production
        PlayerDataUtil.LoadPlayerData(); // TODO: remove in production
        InitItems();
        InitGold();
        InitEarnedStar();
	}

    public void CloseAchievementInfoPanel()
    {
        achievementInfoPanel.SetActive(false);
    }
	
	public void AchievementClicked(Achievement achievement)
    {
        
        achievementInfoPanel.SetActive(true);
        // Set sprites
        switch(achievement.type)
        {
            case Constants.AchievementTypes.destroyBomb:
                achievementInfoPanel.GetComponentsInChildren<Image>()[2].sprite = destroyBombPrefab.GetComponent<Image>().sprite;
                break;
            case Constants.AchievementTypes.earnGold:
                achievementInfoPanel.GetComponentsInChildren<Image>()[2].sprite = earnGoldPrefab.GetComponent<Image>().sprite;
                break;
            case Constants.AchievementTypes.getCombo:
                achievementInfoPanel.GetComponentsInChildren<Image>()[2].sprite = getComboPrefab.GetComponent<Image>().sprite;
                break;
            case Constants.AchievementTypes.getStar:
                achievementInfoPanel.GetComponentsInChildren<Image>()[2].sprite = getStarPrefab.GetComponent<Image>().sprite;
                break;
            case Constants.AchievementTypes.getUpgrade:
                achievementInfoPanel.GetComponentsInChildren<Image>()[2].sprite = getUpgradePrefab.GetComponent<Image>().sprite;
                break;
            case Constants.AchievementTypes.purchasePowerUp:
                achievementInfoPanel.GetComponentsInChildren<Image>()[2].sprite = purchasePowerupPrefab.GetComponent<Image>().sprite;
                break;
        }

        achievementInfoPanel.GetComponentsInChildren<Text>()[0].text = achievement.description;
        achievementInfoPanel.GetComponentsInChildren<Text>()[1].text = "Award: " + achievement.award + " gold";
        if (achievement.earned)
        {
            achievementInfoPanel.GetComponentsInChildren<Text>()[2].text = "EARNED";
        }
        else
        {
            achievementInfoPanel.GetComponentsInChildren<Text>()[2].text = "In progress: " + achievement.progress + "%";
        }
    }

    public void InitItems()
    {
        GameObject achievementContent = GameObject.Find("AchievementContent");

        for (int i = 0; i < Constants.ACHIEVEMENT_MAX_LEVEL; i++)
        {
            GameObject destroyBomb = Instantiate(destroyBombPrefab);
            GameObject earnGold = Instantiate(earnGoldPrefab);
            GameObject getCombo = Instantiate(getComboPrefab);
            GameObject getStar = Instantiate(getStarPrefab);

            destroyBomb.GetComponent<Achievement>().setData(i + 1);
            earnGold.GetComponent<Achievement>().setData(i + 1);
            getCombo.GetComponent<Achievement>().setData(i + 1);
            getStar.GetComponent<Achievement>().setData(i + 1);

            destroyBomb.transform.SetParent(achievementContent.transform);
            earnGold.transform.SetParent(achievementContent.transform);
            getCombo.transform.SetParent(achievementContent.transform);
            getStar.transform.SetParent(achievementContent.transform);
        }
    }

    public void InitGold()
    {
        currentGold.GetComponentInChildren<Text>().text = PlayerDataUtil.playerData.gold.ToString();
    }

    public void InitEarnedStar()
    {
        currentEarnedStar.GetComponentInChildren<Text>().text = PlayerDataUtil.playerData.earnedStars.ToString();
    }
}
