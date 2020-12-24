using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerBall : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 5;
    public int score = 0;
    public bool canTakeDamage = true;
    public float moveSpeed = 3f;
    public bool isOneHitDead = true;
    public bool isDead = false;

    public Color startColor;
    public Color currentColor;
    public SpriteRenderer renderer;
    public TrailRenderer trail;
    public Light2D light;

    [HideInInspector]
    public Rigidbody2D rbd2;

    private void Awake()
    {
        rbd2 = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        SetColor(startColor);
        if (!isOneHitDead)
            SetHealth(maxHealth);
        else
            SetHealth(1);
    }

    void FixedUpdate()
    {
        Vector3 acc = Input.acceleration;
        acc = Quaternion.Euler(80, 0, 0) * acc;

        if(rbd2.velocity.magnitude < 0.2f)
        {
            if (trail.gameObject.activeSelf)
                trail.gameObject.SetActive(false);
        } else
        {
            if (!trail.gameObject.activeSelf)
                trail.gameObject.SetActive(true);
        }

        rbd2.AddForce(acc * moveSpeed);
    }

    public void SetHealth(int newHealth)
    {
        currentHealth = newHealth;
        HUD.instance.SetHealth(newHealth);
    }

    public void SetColor(Color newColor)
    {
        currentColor = newColor;
        renderer.color = newColor;
        trail.startColor = newColor;
        trail.endColor = newColor;
        if (light != null)
            light.color = newColor;
    }

    public int TakeDamage(int damage)
    {
        if (isOneHitDead && !isDead)
        {
            Die();
            canTakeDamage = false;
            return 0;
        }

        if (canTakeDamage)
        {
            SetHealth(currentHealth - damage);
        }

        return currentHealth;
    }

    public void Die()
    {
        SetHealth(0);
        isDead = true;
        LevelManager.instance.SetGameOver();
    }

    public int AddScore(int amount)
    {
        score += amount;
        HUD.instance.SetScore(score);
        return score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Touchable obj = collision.gameObject.GetComponent<Touchable>();
        if (obj != null)
        {
            obj.OnTouchPlayer(this);
        }
    }

    public void FreezePlayer()
    {
        rbd2.simulated = false;
    }

    public int IncreaseHealth(int amount)
    {
        SetHealth(currentHealth + amount);
        return currentHealth;
    }
}

