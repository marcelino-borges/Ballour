using UnityEngine;
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
    public int collectables;
    public float verticalMultiplier = 2f;

    public Color startColor;
    public Color currentColor;
    public SpriteRenderer spriteRenderer;
    public TrailRenderer trail;
    public Light2D light2D;

    [HideInInspector]
    public Rigidbody2D rbd2;

    public int coins;

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
        Vector3 acc = GetAccelerometerDirection();

        rbd2.AddForce(new Vector3(acc.x, (acc.y * verticalMultiplier), acc.z) * moveSpeed);

        if (rbd2.velocity.magnitude < 0.2f)
        {
            if (trail.gameObject.activeSelf)
                trail.gameObject.SetActive(false);
        }
        else
        {
            if (!trail.gameObject.activeSelf)
                trail.gameObject.SetActive(true);
        }
    }

    private static Vector3 GetAccelerometerDirection()
    {
        Vector3 acc = Input.acceleration;
        acc = Quaternion.Euler(70, 0, 0) * acc;
        acc = Vector3.Normalize(acc);
        return acc;
    }

    public void SetHealth(int newHealth)
    {
        currentHealth = newHealth;
        HUD.instance.SetHealth(newHealth);
    }

    public void SetColor(Color newColor)
    {
        currentColor = newColor;
        spriteRenderer.color = newColor;
        trail.startColor = newColor;
        trail.endColor = newColor;
        if (light2D != null)
            light2D.color = newColor;
    }

    public int TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            HUD.instance.BlinkDamagePanel();

            if (isOneHitDead && !isDead)
            {
                SetHealth(0);
                Die();
                canTakeDamage = false;
                return currentHealth;
            }

            SetHealth(currentHealth - damage);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                Die();            
            }
        }

        return currentHealth;
    }

    public void Die()
    {
        isDead = true;
        LevelManager.instance.SetGameOver();
    }

    public int AddScore(int amount)
    {
        score += amount;
        HUD.instance.SetScore(score);
        return score;
    }

    public int GatherCollectable(int amount)
    {
        collectables++;
        return collectables;
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

