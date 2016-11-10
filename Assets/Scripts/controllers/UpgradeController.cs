using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeController : MonoBehaviour
{

    public GameObject resetStarPanel;
    bool ShowResetStarConfirm;
    bool ShowAdsOffer;

    // Use this for initialization
    void Start()
    {
        ShowResetStarConfirm = false;
        ShowAdsOffer = false;
        // Init a fake player data for first time
        PlayerDataUtil.SavePlayerDataFirstTime(); //TODO: remove in production
        PlayerDataUtil.LoadPlayerData();  //TODO: remove in production
        InitAllItems();
    }

    void InitAllItems()
    {
        // Init all upgrade items
        InitUpgradeItem("Normal", PlayerDataUtil.playerData.normalLevel, Constants.UPGRADE_MAX_LEVEL, Constants.NORMAL_BOMB_UPGRADE_BASE_COST);
        InitUpgradeItem("Shooter", PlayerDataUtil.playerData.shooterLevel, Constants.UPGRADE_MAX_LEVEL, Constants.SHOOTER_BOMB_UPGRADE_BASE_COST);
        InitUpgradeItem("Target", PlayerDataUtil.playerData.targetLevel, Constants.UPGRADE_MAX_LEVEL, Constants.TARGET_BOMB_UPGRADE_BASE_COST);
        InitUpgradeItem("Wave", PlayerDataUtil.playerData.waveLevel, Constants.UPGRADE_MAX_LEVEL, Constants.WAVE_BOMB_UPGRADE_BASE_COST);
        InitUpgradeItem("Gold", PlayerDataUtil.playerData.goldLevel, Constants.UPGRADE_MAX_LEVEL, Constants.GOLD_UPGRADE_BASE_COST);

        // Init earned and remain stars
        InitEarnedAndRemainStars();

        // Init gold
        InitCurrentGold();

        // Init reset stars
        InitResetStars();
    }

    void InitUpgradeItem(string itemName, int level, int levelMax, int baseCost)
    {
        level = level + 1;
        GameObject levelObj = GameObject.Find(itemName + "Level");
        GameObject valueObj = GameObject.Find(itemName + "Value");
        Button btn = GameObject.Find(itemName + "Button").GetComponent<Button>();
        if (level == levelMax)
        {
            levelObj.GetComponent<Text>().text = "Level MAX";
            levelObj.GetComponent<Text>().color = Color.red;
            valueObj.GetComponent<Text>().text = "--";
            btn.interactable = false;
        }
        else
        {
            levelObj.GetComponent<Text>().text = "Level " + level.ToString();
            levelObj.GetComponent<Text>().color = Color.black;
            valueObj.GetComponent<Text>().text = (baseCost * level).ToString();
            btn.interactable = true;
        }

        if (PlayerDataUtil.playerData.earnedStars - PlayerDataUtil.playerData.spentStars < baseCost * level)
        {
            btn.interactable = false;
        }
    }

    void InitEarnedAndRemainStars()
    {
        GameObject.Find("EarnedValue").GetComponent<Text>().text = PlayerDataUtil.playerData.earnedStars.ToString();
        GameObject.Find("RemainValue").GetComponent<Text>().text = (PlayerDataUtil.playerData.earnedStars - PlayerDataUtil.playerData.spentStars).ToString();
    }

    void InitCurrentGold()
    {
        GameObject.Find("CurrentValue").GetComponent<Text>().text = PlayerDataUtil.playerData.gold.ToString();
    }

    void InitResetStars()
    {
        GameObject.Find("ResetValue").GetComponent<Text>().text = ((PlayerDataUtil.playerData.starResetedTime + 1) * Constants.RESET_STARS_BASE_COST).ToString();
    }

    public void ResetStars()
    {
        int currentGold = PlayerDataUtil.playerData.gold;
        int resetPrice = (PlayerDataUtil.playerData.starResetedTime + 1) * Constants.RESET_STARS_BASE_COST;
        if (resetPrice <= currentGold)
        {
            resetStarPanel.GetComponentInChildren<Text>().text = "Do you really wanna reset stars with " + (PlayerDataUtil.playerData.starResetedTime + 1) * Constants.RESET_STARS_BASE_COST + " gold?";
            ShowResetStarConfirm = true;
            ShowAdsOffer = false;
        }
        else
        {
            resetStarPanel.GetComponentInChildren<Text>().text = "You do not have enough gold to reset, You can view an ads to gain '" + ((PlayerDataUtil.playerData.starResetedTime + 1) * Constants.RESET_STARS_BASE_COST) / 5 + "' gold?";
            ShowAdsOffer = true;
            ShowResetStarConfirm = false;
        }

        resetStarPanel.SetActive(true);
    }

    public void ResetStarActionOK()
    {
        if(ShowResetStarConfirm)
        {
            PlayerDataUtil.ResetStars();
            InitAllItems();
        } else if(ShowAdsOffer)
        {
            // Display ads
            Debug.Log("ads displayed");
        }
        resetStarPanel.SetActive(false);
    }

    public void ResetStarActionCancel()
    {
        resetStarPanel.SetActive(false);
    }

    public void UpgradeItem(string itemName)
    {
        int level = 0;
        int baseCost = 0;

        switch (itemName)
        {
            case "Normal":
                level = PlayerDataUtil.playerData.normalLevel;
                baseCost = Constants.NORMAL_BOMB_UPGRADE_BASE_COST;
                PlayerDataUtil.playerData.normalLevel++;
                break;
            case "Shooter":
                level = PlayerDataUtil.playerData.shooterLevel;
                baseCost = Constants.SHOOTER_BOMB_UPGRADE_BASE_COST;
                PlayerDataUtil.playerData.shooterLevel++;
                break;
            case "Target":
                level = PlayerDataUtil.playerData.targetLevel;
                baseCost = Constants.TARGET_BOMB_UPGRADE_BASE_COST;
                PlayerDataUtil.playerData.targetLevel++;
                break;
            case "Wave":
                level = PlayerDataUtil.playerData.waveLevel;
                baseCost = Constants.WAVE_BOMB_UPGRADE_BASE_COST;
                PlayerDataUtil.playerData.waveLevel++;
                break;
            case "Gold":
                level = PlayerDataUtil.playerData.goldLevel;
                baseCost = Constants.GOLD_UPGRADE_BASE_COST;
                PlayerDataUtil.playerData.goldLevel++;
                break;
        }
        PlayerDataUtil.playerData.spentStars += baseCost * level;
        InitAllItems();
        PlayerDataUtil.playerData.totalUpgrade++; // Update total upgrade to gain achievement
        PlayerDataUtil.SavePlayerData();
    }
}
