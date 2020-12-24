using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public PlayerBall player;
    public bool isGameOver = false;

    public int totalObjectivesInLevel = 0;
    public int objectivesDestroyed = 0;
    public float delayToShowUI = .5f;

    void Start()
    {
        if (instance == null)
            instance = this;

        totalObjectivesInLevel = GameObject.FindObjectsOfType<DestroyableBrick>().Length;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBall>();
    }

    void Update()
    {
        
    }

    public void SetGameOver()
    {
        StartCoroutine(SetGameOverCo());
    }

    private IEnumerator SetGameOverCo()
    {
        player.FreezePlayer();
        isGameOver = true;
        yield return new WaitForSeconds(delayToShowUI);
        ShowUI(gameOverPanel);
    }

    public void SetVictory()
    {
        StartCoroutine(SetVictoryCo());
    }

    private IEnumerator SetVictoryCo()
    {
        player.FreezePlayer();
        yield return new WaitForSeconds(delayToShowUI);
        ShowUI(victoryPanel);
    }

    private void ShowUI(GameObject ui)
    {
        ui.SetActive(true);
    }

    public void CountDestroyedObjective()
    {
        objectivesDestroyed++;

        if (objectivesDestroyed >= totalObjectivesInLevel)
            SetVictory();
    }
}
