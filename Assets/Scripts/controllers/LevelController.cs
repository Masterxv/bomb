using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject levelPrefab;
    public Sprite levelUnlocked;
    public Sprite levelLocked;

    // Use this for initialization
    void Start()
    {
        //PlayerDataUtil.SavePlayerDataFirstTime();
        PlayerDataUtil.LoadPlayerData();

        for (int i = 0; i < Constants.TOTAL_LEVEL; i++)
        {
            GameObject levelPrefabClone = Instantiate(levelPrefab);
            
            // Add levelPrefab to levels canvas
            levelPrefabClone.transform.SetParent(transform);

            // Set properties for level prefabs children components
            // Set level name
            levelPrefabClone.GetComponentInChildren<Text>().text = (i + 1) + "";

            // Set level image, depend on status of level of players
            // Get user data
            bool unlocked = i + 1 <= PlayerDataUtil.playerData.unlockedLevelIndex;

            // Set level data and even when click
            Button b = levelPrefabClone.GetComponent<Button>();
            if (unlocked)
            {
                levelPrefabClone.GetComponentInChildren<Image>().sprite = levelUnlocked;
                b.onClick.AddListener(() => GoToLevel(i));
            }
            else
            {
                levelPrefabClone.GetComponentInChildren<Image>().sprite = levelLocked;
                b.interactable = false;
            }
        }
    }

    public static void GoToLevel(int levelIndex)
    {
        // Load level data
        Level level = LevelUtil.LoadLevelData(levelIndex);
        // Set seleted level data to main scene
        LevelUtil.setCurrentLevel(level);
        // Load scene
        SceneManager.LoadScene((int)SceneEnum.MainScene);
    }
}
