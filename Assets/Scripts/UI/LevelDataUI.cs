using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDataUI : MonoBehaviour
{
    public int buildIndex;
    public TextMeshProUGUI levelNameTxt;
    public GameObject[] stars;
    public Button button;

    public static int latestLevelPersisted = 0;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    void Start()
    {
        levelNameTxt.text = buildIndex < 10 ? "0" + buildIndex : buildIndex.ToString();

        PlayerPersistenceData playerData = PlayerPersistence.LoadPlayerData();

        if(playerData != null)
        {
            LevelData level = PlayerPersistence.GetLevelPersisted(buildIndex);

            if(level != null)
            {
                for (int i = 0; i < level.stars; i++)
                {
                    stars[i].SetActive(true);
                }

                button.interactable = true;
            } else
            {
                if (buildIndex <= LevelSelectionUI.instance.latestLevelPlayed + 1)
                    button.interactable = true;
                else
                    button.interactable = false;
            }
        }

        if (buildIndex == 1 && !button.interactable)
            button.interactable = true;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(buildIndex);    
    }
}
