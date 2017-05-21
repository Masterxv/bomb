using System;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MySingleton<WallManager>
{
    // Wall
    public GameObject normalWall;
    public GameObject contraryWall;

    public void CreateWall(WallInfo wallInfo)
    {
        GameObject wall = null;
        switch (wallInfo.type)
        {
            case Constants.WallTypes.normal:
                wall = Instantiate(normalWall, wallInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                break;
            case Constants.WallTypes.contrary:
                wall = Instantiate(contraryWall, wallInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
                break;
        }
        if (wall == null)
        {
            wall = Instantiate(normalWall, wallInfo.initPosition.GetV3(), Quaternion.identity) as GameObject;
        }
        wall.GetComponent<Wall>().setWallData(wallInfo);
    }
}
