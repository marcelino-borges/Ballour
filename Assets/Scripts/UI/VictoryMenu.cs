using System.Collections;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{
    public StarUI[] starsUI;
    public float delayBetweenEachStarActivation = 1f;
    public AudioClip victorySfx;

    private bool hasShownStars = false;

    public void SetStarsFromLevel()
    {
        if(victorySfx != null)
            SoundManager.instance.PlaySound2D(victorySfx);

        StartCoroutine(SetStarsFromLevelCo());
    }

    private IEnumerator SetStarsFromLevelCo()
    {
        int stars = LevelManager.instance.starsWonInLevel;

        for (int i = 0; i < stars; i++)
        {
            yield return new WaitForSeconds(delayBetweenEachStarActivation);
            starsUI[i].Activate();
        }
        yield return new WaitForSeconds(delayBetweenEachStarActivation);

        hasShownStars = true;
    }

    public void LoadNextLevel()
    {
        if(hasShownStars)
            CommonUI.LoadNextLevel();
    }
    public void LoadMainMenu()
    {
        if (hasShownStars)
            CommonUI.LoadMainMenu();
    }

    public void ReloadLevel()
    {
        if (hasShownStars)
            CommonUI.ReloadLevel();
    }
}
