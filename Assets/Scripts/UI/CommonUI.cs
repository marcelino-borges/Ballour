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
        SceneManager.LoadScene("MainMenu");
    }

    public static void ReloadLevel()
    {
        SoundManager.instance.PlayButtonSfx();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
