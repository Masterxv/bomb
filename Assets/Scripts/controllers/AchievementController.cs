using UnityEngine;
using System.Collections;

public class AchievementController : MonoBehaviour {

    public GameObject destroyBombPrefab;
    public GameObject earnGoldPrefab;
    public GameObject getStarPrefab;
    public GameObject getUpgradePrefab;
    public GameObject getComboPrefab;
    public GameObject purchasePowerupPrefab;

    public GameObject achievementInfoPanel;

    private int numberOfColumn = 6;
	// Use this for initialization
	void Start () {
        PlayerDataUtil.SavePlayerDataFirstTime(); // TODO: remove in production
        PlayerDataUtil.LoadPlayerData(); // TODO: remove in production
        GameObject achievementContent = GameObject.Find("AchievementContent");

        for (int i=0; i< Constants.ACHIEVEMENT_MAX_LEVEL; i++)
        {
            GameObject destroyBomb = Instantiate(destroyBombPrefab);
            GameObject earnGold = Instantiate(earnGoldPrefab);
            GameObject getCombo = Instantiate(getComboPrefab);
            GameObject getStar = Instantiate(getStarPrefab);
            GameObject getUpgrade = Instantiate(getUpgradePrefab);
            GameObject purchasePowerup = Instantiate(purchasePowerupPrefab);

            destroyBomb.GetComponent<Achievement>().setData(i + 1);
            earnGold.GetComponent<Achievement>().setData(i + 1);
            getCombo.GetComponent<Achievement>().setData(i + 1);
            getStar.GetComponent<Achievement>().setData(i + 1);
            getUpgrade.GetComponent<Achievement>().setData(i + 1);
            purchasePowerup.GetComponent<Achievement>().setData(i + 1);

            destroyBomb.transform.SetParent(achievementContent.transform);
            earnGold.transform.SetParent(achievementContent.transform);
            getCombo.transform.SetParent(achievementContent.transform);
            getStar.transform.SetParent(achievementContent.transform);
            getUpgrade.transform.SetParent(achievementContent.transform);
            purchasePowerup.transform.SetParent(achievementContent.transform);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
