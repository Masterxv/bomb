using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LevelUtil.init(); // Init levels data
        UpgradeUtil.init(); // Get user data

        GameObject levelsCanvas =  GameObject.Find("Levels") as GameObject;
        GameObject levelPrefab = (GameObject)Instantiate(Resources.Load("Level"));
        float levelPrefabWidth = levelPrefab.GetComponent<RectTransform>().sizeDelta.x;
        float levelPrefabHeight = levelPrefab.GetComponent<RectTransform>().sizeDelta.y;
        float xOffset = 0;
        float yOffset = 0;

        for (int i=0; i<LevelUtil.levels.Count; i++)
        {
            Level level = LevelUtil.getLevel(i);
            GameObject levelPrefabClone = Instantiate(levelPrefab);

            // Add levelPrefab to levels canvas
            levelPrefabClone.transform.parent = levelsCanvas.transform;

            // Set properties for level prefabs children components
            // Set level name
            levelPrefabClone.GetComponentInChildren<Text>().text = level.index + "";
            // Set level position, depend on level index
            int xChecker = level.index % 5;
            switch (xChecker)
            {
                case 1:
                    xOffset = -2 * (levelPrefabWidth + Constants.LEVEL_MARGIN);
                    break;
                case 2:
                    xOffset = -(levelPrefabWidth + Constants.LEVEL_MARGIN);
                    break;
                case 3:
                    xOffset = 0;
                    break;
                case 4:
                    xOffset = levelPrefabWidth + Constants.LEVEL_MARGIN;
                    break;
                case 0:
                    xOffset = 2 * (levelPrefabWidth + Constants.LEVEL_MARGIN);
                    break;
            }

            int yChecker = level.index / 5;
            if(xChecker == 0)
            {
                yOffset = - (yChecker - 1) * (levelPrefabHeight + Constants.LEVEL_MARGIN);
            } else
            {
                yOffset = -yChecker * (levelPrefabHeight + Constants.LEVEL_MARGIN);
            }

            levelPrefabClone.transform.position = levelsCanvas.transform.position +  new Vector3(xOffset, yOffset, 0);
            // Set level image, depend on status of level of players

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
