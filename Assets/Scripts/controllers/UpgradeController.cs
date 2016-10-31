using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeController : MonoBehaviour
{

    bool ShowResetStarConfirm;
    bool ShowAdsOffer;

    // Use this for initialization
    void Start()
    {
        ShowResetStarConfirm = false;
        ShowAdsOffer = false;
        // Init a fake player data for first time
        // PlayerDataUtil.SavePlayerDataFirstTime();
        // PlayerDataUtil.LoadPlayerData();
        InitAllItems();
        GameObject upgradeCanvas = GameObject.Find("UpgradeCanvas") as GameObject;
        RectTransform rt = upgradeCanvas.GetComponent<RectTransform>();
        rt.anchorMin = new Vector2(0.5f, 1f);
        rt.anchorMax = new Vector2(0.5f, 1f);
        rt.sizeDelta = new Vector2(600, 1000);
        rt.anchoredPosition = new Vector2(0, -rt.sizeDelta.y / 2 - 100);
    }

    void InitAllItems()
    {
        // Init all upgrade items
        InitUpgradeItem("Normal", PlayerDataUtil.playerData.normalLevel, Constants.BOMB_UPGRADE_MAX_LEVEL, Constants.NORMAL_BOMB_UPGRADE_BASE_COST);
        InitUpgradeItem("Shooter", PlayerDataUtil.playerData.shooterLevel, Constants.BOMB_UPGRADE_MAX_LEVEL, Constants.SHOOTER_BOMB_UPGRADE_BASE_COST);
        InitUpgradeItem("Target", PlayerDataUtil.playerData.targetLevel, Constants.BOMB_UPGRADE_MAX_LEVEL, Constants.TARGET_BOMB_UPGRADE_BASE_COST);
        InitUpgradeItem("Wave", PlayerDataUtil.playerData.waveLevel, Constants.BOMB_UPGRADE_MAX_LEVEL, Constants.WAVE_BOMB_UPGRADE_BASE_COST);
        InitUpgradeItem("Gold", PlayerDataUtil.playerData.goldLevel, Constants.GOLD_UPGRADE_MAX_LEVEL, Constants.GOLD_UPGRADE_BASE_COST);

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

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetStars()
    {
        int currentGold = PlayerDataUtil.playerData.gold;
        int resetPrice = PlayerDataUtil.playerData.starResetedTime * Constants.RESET_STARS_BASE_COST;
        if (resetPrice <= currentGold)
        {
            // Show reset confirm dialog
            ShowResetStarConfirm = true;
        }
        else
        {
            // Show ads offer dialog
            ShowAdsOffer = true;
        }
    }

    void OnGUI()
    {
        if (ShowResetStarConfirm)
        {
            GUI.ModalWindow(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                   , 300, 150), ShowResetStarConfirmDialog, "Reset Stars");
        }

        if (ShowAdsOffer)
        {
            GUI.ModalWindow(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
                   , 300, 150), ShowResetStarAdsOfferDialog, "Reset Stars, Ads offer!");
        }
    }

    void ShowResetStarConfirmDialog(int windowID)
    {
        // You may put a label to show a message to the player

        GUI.Label(new Rect(50, 30, 200, 90), "Do you really wanna reset star with " + PlayerDataUtil.playerData.starResetedTime * Constants.RESET_STARS_BASE_COST + " gold?");

        // You may put a button to close the pop up too

        if (GUI.Button(new Rect(80, 100, 50, 30), "OK"))
        {
            ShowResetStarConfirm = false;
            PlayerDataUtil.ResetStars();
            InitAllItems();
        }
        if (GUI.Button(new Rect(170, 100, 50, 30), "Cancel"))
        {
            ShowResetStarConfirm = false;
        }
    }


    void ShowResetStarAdsOfferDialog(int windowID)
    {
        // You may put a label to show a message to the player

        GUI.Label(new Rect(50, 30, 200, 90), "You do not have enough gold to reset, You can view an ads to gain '" + (PlayerDataUtil.playerData.starResetedTime * Constants.RESET_STARS_BASE_COST)/5 + "' gold?");

        // You may put a button to close the pop up too

        if (GUI.Button(new Rect(80, 100, 50, 30), "OK"))
        {
            // Show ads then callback to reset stars
        }
        if (GUI.Button(new Rect(170, 100, 50, 30), "Cancel"))
        {
            ShowAdsOffer = false;
        }
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
        PlayerDataUtil.SavePlayerData();
    }
}
