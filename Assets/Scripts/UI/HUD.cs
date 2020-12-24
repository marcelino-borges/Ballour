using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;
    public PlayerBall player;

    private void Start()
    {
        if (instance == null)
            instance = this;

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBall>();
    }

    public void SetHealth(int health)
    {
        print("SetHealth");
        healthText.text = health < 10 ? "0" + health : health.ToString();
    }

    public void SetScore(int score)
    {
        print("SetScore");
        scoreText.text = score < 10 ? "0" + score : score.ToString();
    }

}
