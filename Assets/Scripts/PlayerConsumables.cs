using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConsumables : MonoBehaviour
{
    [Header("References")]
    public Inventory inventory;
    public ItemData appleItem;
    public PlayerHealth playerHealth;

    [Header("Healing")]
    public int healAmount = 20;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip eatAppleSound;

    private void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = GetComponent<PlayerHealth>();
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void OnUseApple(InputValue value)
    {
        if (!value.isPressed)
        {
            return;
        }

        UseApple();
    }

    private void UseApple()
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory is not assigned.");
            return;
        }

        if (appleItem == null)
        {
            Debug.LogError("Apple Item is not assigned.");
            return;
        }

        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth was not found.");
            return;
        }

        if (playerHealth.health >= 100)
        {
            Debug.Log("Health is already full.");
            return;
        }

        bool removedApple = inventory.RemoveItem(appleItem, 1);

        if (!removedApple)
        {
            Debug.Log("No apples available.");
            return;
        }

        playerHealth.Heal(healAmount);

        if (audioSource != null && eatAppleSound != null)
        {
            audioSource.PlayOneShot(eatAppleSound);
        }

        Debug.Log("Apple eaten. Current health: " + playerHealth.health);
    }
}