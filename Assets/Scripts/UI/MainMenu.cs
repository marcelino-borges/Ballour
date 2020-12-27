using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SoundButton soundButton;

    private void Start()
    {
        CheckFirstTimePlaying();
        SetMuteIconVisible(MusicManager.instance.isMuted);
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Mute()
    {
        bool mute = MusicManager.instance.isMuted;
        
        MusicManager.instance.Mute(!mute);
        SoundManager.instance.Mute(!mute);
        SetMuteIconVisible(!mute);
    }

    public void SetMuteIconVisible(bool visible)
    {
        soundButton.SetMuteIconVisible(visible);
    }

    private void CheckFirstTimePlaying()
    {
        PlayerPersistence.LoadPlayerData();
    }
}
