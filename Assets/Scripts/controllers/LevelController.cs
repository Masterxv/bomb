using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public int yDefaultOffset;
    // Use this for initialization
    void Start()
    {
        //PlayerDataUtil.SavePlayerDataFirstTime();
        PlayerDataUtil.LoadPlayerData();

        GameObject levelsCanvas = GameObject.Find("LevelCanvas") as GameObject;
        GameObject levelScrollView = GameObject.Find("LevelScrollView") as GameObject;

        GameObject levelPrefab = (GameObject)Instantiate(Resources.Load("Prefabs/Level"));
        float levelPrefabWidth = levelPrefab.GetComponent<RectTransform>().sizeDelta.x;
        float levelPrefabHeight = levelPrefab.GetComponent<RectTransform>().sizeDelta.y;
        float xOffset = 0;
        float yOffset = 0;

        for (int i = 0; i < Constants.TOTAL_LEVEL; i++)
        {
            int levelIndex = i + 1;
            GameObject levelPrefabClone = Instantiate(levelPrefab);

            // Add levelPrefab to levels canvas
            levelPrefabClone.transform.SetParent(levelsCanvas.transform);

            // Set properties for level prefabs children components

            // Set level name
            levelPrefabClone.GetComponentInChildren<Text>().text = levelIndex + "";

            // Set level position, depend on level index
            // Perform xOffset
            int xChecker = levelIndex % 6;
            if (xChecker == 0)
            {
                xChecker = 6;
            }
            xOffset = (xChecker - 3.5f) * (levelPrefabWidth + Constants.LEVEL_MARGIN);

            // Perform y offset
            int yChecker = levelIndex / 6;
            if (xChecker == 6)
            {
                yOffset = -(yChecker - 1) * (levelPrefabHeight + Constants.LEVEL_MARGIN);
            }
            else
            {
                yOffset = -yChecker * (levelPrefabHeight + Constants.LEVEL_MARGIN);
            }

            levelPrefabClone.transform.position = levelsCanvas.transform.position + new Vector3(xOffset, yOffset + yDefaultOffset, 0);
            // Set level image, depend on status of level of players
            // Load level sprites
            Sprite level_0_star = Resources.Load<Sprite>("Sprites/levels/level-0-star");
            Sprite level_1_star = Resources.Load<Sprite>("Sprites/levels/level-1-star");
            Sprite level_2_star = Resources.Load<Sprite>("Sprites/levels/level-2-star");
            Sprite level_3_star = Resources.Load<Sprite>("Sprites/levels/level-3-star");
            Sprite level_locked = Resources.Load<Sprite>("Sprites/levels/level-locked");

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
