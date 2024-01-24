using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int LevelId) // Load clicked level
    {
        string levelName = "Level " + LevelId;
        SceneManager.LoadScene(levelName);
    }
}
