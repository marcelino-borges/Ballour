using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SoundManager.instance.PlayButtonSfx();
        SceneManager.LoadScene(0);
    }

    public void ReloadLevel()
    {
        SoundManager.instance.PlayButtonSfx();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
