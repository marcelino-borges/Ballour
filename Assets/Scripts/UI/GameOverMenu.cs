using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        CommonUI.LoadMainMenu();
    }

    public void ReloadLevel()
    {
        CommonUI.ReloadLevel();
    }
}
