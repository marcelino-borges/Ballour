using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SoundManager.instance.PlayButtonSfx();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel()
    {
        SoundManager.instance.PlayButtonSfx();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
