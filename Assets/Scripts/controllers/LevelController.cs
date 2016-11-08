using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject levelPrefab;
    public Sprite level_0_star;
    public Sprite level_1_star;
    public Sprite level_2_star;
    public Sprite level_3_star;
    public Sprite level_locked;

    // Use this for initialization
    void Start()
    {
        //PlayerDataUtil.SavePlayerDataFirstTime();
        PlayerDataUtil.LoadPlayerData();

        for (int i = 0; i < Constants.TOTAL_LEVEL; i++)
        {
            int levelIndex = i + 1;
            GameObject levelPrefabClone = Instantiate(levelPrefab);
            
            // Add levelPrefab to levels canvas
            levelPrefabClone.transform.SetParent(transform);

            // Set properties for level prefabs children components
            // Set level name
            levelPrefabClone.GetComponentInChildren<Text>().text = levelIndex + "";

            // Set level image, depend on status of level of players
            // Get user data
            int stars = PlayerDataUtil.playerData.stars[levelIndex - 1];

            // Set level data and even when click
            Button b = levelPrefabClone.GetComponent<Button>();
            if (stars == -1)
            {
                b.interactable = false;
            }
            else
            {
                b.onClick.AddListener(() => GoToLevel(levelIndex));
            }

            switch (stars)
            {
                case -1:
                    levelPrefabClone.GetComponentInChildren<Image>().sprite = level_locked;
                    break;
                case 0:
                    levelPrefabClone.GetComponentInChildren<Image>().sprite = level_0_star;
                    break;
                case 1:
                    levelPrefabClone.GetComponentInChildren<Image>().sprite = level_1_star;
                    break;
                case 2:
                    levelPrefabClone.GetComponentInChildren<Image>().sprite = level_2_star;
                    break;
                case 3:
                    levelPrefabClone.GetComponentInChildren<Image>().sprite = level_3_star;
                    break;
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
        SceneManager.LoadScene(2);
    }
}
