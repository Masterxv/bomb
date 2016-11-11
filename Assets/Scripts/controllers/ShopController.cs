using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShopController : MonoBehaviour {

    public GameObject extraBomb;
    public GameObject extraClick;
    public GameObject watchAdsPowerup;
    public GameObject watchAdsGold;
    public GameObject buyGoldPackage1;
    public GameObject buyGoldPackage2;
    public GameObject buyGoldPackage3;

    public GameObject currentGold;
    public GameObject currentMoreBomb;
    public GameObject currentMoreClick;

    // Use this for initialization
    void Start () {
        PlayerDataUtil.SavePlayerDataFirstTime();
        PlayerDataUtil.LoadPlayerData();
        InitItems();
        InitGold();
        InitMoreBomb();
        InitMoreClick();
	}

    public void InitItems()
    {
        // Extra bomb
        extraBomb.GetComponentsInChildren<Text>()[3].text = Constants.MORE_BOMB_PRICE.ToString();
        extraBomb.GetComponentInChildren<Button>().onClick.AddListener(BuyMoreBomb);
        // Extra click/touch
        extraClick.GetComponentsInChildren<Text>()[3].text = Constants.MORE_CLICK_PRICE.ToString();
        extraClick.GetComponentInChildren<Button>().onClick.AddListener(BuyMoreTouch);
        // Watch ads powerup
        watchAdsPowerup.GetComponentInChildren<Button>().onClick.AddListener(WatchAdsToGetPowerup);
        // Watch ads gold
        watchAdsGold.GetComponentInChildren<Button>().onClick.AddListener(WatchAdsToGetGold);
        // Buy gold package 1
        buyGoldPackage1.GetComponentsInChildren<Text>()[0].text = "Buy " + Constants.GOLD_PACKAGE_1_VALUE + " gold";
        buyGoldPackage1.GetComponentsInChildren<Text>()[3].text = Constants.GOLD_PACKAGE_1_PRICE.ToString();
        buyGoldPackage1.GetComponentInChildren<Button>().onClick.AddListener(BuyGoldPackage1);
        // Buy gold package 2
        buyGoldPackage2.GetComponentsInChildren<Text>()[0].text = "Buy " + Constants.GOLD_PACKAGE_2_VALUE + " gold";
        buyGoldPackage2.GetComponentsInChildren<Text>()[3].text = Constants.GOLD_PACKAGE_2_PRICE.ToString();
        buyGoldPackage2.GetComponentInChildren<Button>().onClick.AddListener(BuyGoldPackage2);
        // Buy gold package 3
        buyGoldPackage3.GetComponentsInChildren<Text>()[0].text = "Buy " + Constants.GOLD_PACKAGE_3_VALUE + " gold";
        buyGoldPackage3.GetComponentsInChildren<Text>()[3].text = Constants.GOLD_PACKAGE_3_PRICE.ToString();
        buyGoldPackage3.GetComponentInChildren<Button>().onClick.AddListener(BuyGoldPackage3);
    }

    public void BuyMoreBomb()
    {
        if(PlayerDataUtil.playerData.gold > Constants.MORE_BOMB_PRICE)
        {
            PlayerDataUtil.playerData.powerUpMoreBomb++;
            PlayerDataUtil.playerData.gold -= Constants.MORE_BOMB_PRICE;
            PlayerDataUtil.SavePlayerData();
            InitGold();
            InitMoreBomb();
        } else
        {
            // Offer ads
        }
    }

    public void BuyMoreTouch()
    {
        if (PlayerDataUtil.playerData.gold > Constants.MORE_CLICK_PRICE)
        {
            PlayerDataUtil.playerData.powerUpMoreClick++;
            PlayerDataUtil.playerData.gold -= Constants.MORE_CLICK_PRICE;
            PlayerDataUtil.SavePlayerData();
            InitGold();
            InitMoreClick();
        }
        else
        {
            // Offer ads
        }
    }

    public void WatchAdsToGetPowerup()
    {
        // Display ads if have
    }

    public void WatchAdsToGetGold()
    {
        // Display ads if have
    }

    public void BuyGoldPackage1()
    {
        // Inap-purchase panel
    }

    public void BuyGoldPackage2()
    {
        // Inap-purchase panel
    }

    public void BuyGoldPackage3()
    {
        // Inap-purchase panel
    }

    public void InitGold()
    {
        currentGold.GetComponentInChildren<Text>().text = PlayerDataUtil.playerData.gold.ToString();
    }

    public void InitMoreBomb()
    {
        currentMoreBomb.GetComponentInChildren<Text>().text = PlayerDataUtil.playerData.powerUpMoreBomb.ToString();
    }

    public void InitMoreClick()
    {
        currentMoreClick.GetComponentInChildren<Text>().text = PlayerDataUtil.playerData.powerUpMoreClick.ToString();
    }
}
