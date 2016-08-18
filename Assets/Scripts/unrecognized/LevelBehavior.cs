using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelBehavior : MonoBehaviour
{
    Level thisLevel;

    public void setLevel(Level level)
    {
        thisLevel = level;
    }

    public Level getLevel()
    {
        return thisLevel;
    }

    void OnMouseDown()
    {

    }
}
