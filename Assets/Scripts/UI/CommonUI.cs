using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonUI : MonoBehaviour
{
    public static void LoadNextLevel()
    {
        SoundManager.instance.PlayButtonSfx();
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevelIndex);
    }
    public static void LoadMainMenu()
    {
        SoundManager.instance.PlayButtonSfx();
        SceneManager.LoadScene(0);
    }

    public static void ReloadLevel()
    {
        SoundManager.instance.PlayButtonSfx();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
