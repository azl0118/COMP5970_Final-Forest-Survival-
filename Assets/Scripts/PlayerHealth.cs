using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;

    public TextMeshProUGUI healthText;

    void Start()
    {
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        UpdateHealthUI();

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        health += amount;

        if (health > 100)
            health = 100;

        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthText.text = "Health: " + health;
    }

    void Die()
    {
        GameManager.Instance.PlayerDied();
        gameObject.SetActive(false);
        Debug.Log("Player Died");
    }
}