using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerEquipment : MonoBehaviour
{
    [Header("Inventory")]
    public Inventory inventory;
    public ItemData axeItem;
    public ItemData swordItem;

    [Header("Weapon Models")]
    public GameObject axeObject;
    public GameObject swordObject;

    [Header("Combat")]
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public float attackRange = 2.5f;
    public float attackCooldown = 0.8f;

    [Header("Weapon Damage")]
    public int axeDamage = 15;
    public int swordDamage = 30;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip swordSwingSound;

    private Animator animator;
    private ItemData equippedWeapon;
    private bool canAttack = true;

    private void Start()
    {
        // Finds the same child Animator used by PlayerInteraction
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("PlayerEquipment could not find the player Animator.");
        }

        if (inventory == null)
        {
            Debug.LogError("Inventory is not assigned on PlayerEquipment.");
        }

        if (attackPoint == null)
        {
            Debug.LogError("Attack Point is not assigned on PlayerEquipment.");
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        UnequipWeapon();
    }

    public void OnEquipAxe(InputValue value)
    {
        if (!value.isPressed)
        {
            return;
        }

        ToggleWeapon(axeItem, axeObject);
    }

    public void OnEquipSword(InputValue value)
    {
        if (!value.isPressed)
        {
            return;
        }

        ToggleWeapon(swordItem, swordObject);
    }

    public void OnAttack(InputValue value)
    {
        if (!value.isPressed)
        {
            return;
        }

        Attack();
    }

    private void ToggleWeapon(ItemData weapon, GameObject weaponObject)
    {
        if (inventory == null || weapon == null)
        {
            return;
        }

        if (!inventory.HasItem(weapon, 1))
        {
            Debug.Log(weapon.name + " is not in the inventory.");
            return;
        }

        if (equippedWeapon == weapon)
        {
            UnequipWeapon();
            return;
        }

        EquipWeapon(weapon, weaponObject);
    }

    private void EquipWeapon(ItemData weapon, GameObject weaponObject)
    {
        equippedWeapon = weapon;

        if (axeObject != null)
        {
            axeObject.SetActive(false);
        }

        if (swordObject != null)
        {
            swordObject.SetActive(false);
        }

        if (weaponObject != null)
        {
            weaponObject.SetActive(true);
        }

        Debug.Log("Equipped " + weapon.name);
    }

    private void UnequipWeapon()
    {
        equippedWeapon = null;

        if (axeObject != null)
        {
            axeObject.SetActive(false);
        }

        if (swordObject != null)
        {
            swordObject.SetActive(false);
        }
    }

    private void Attack()
    {
        if (equippedWeapon == null)
        {
            Debug.Log("Equip a weapon before attacking.");
            return;
        }

        if (!canAttack)
        {
            return;
        }

        if (attackPoint == null)
        {
            Debug.LogError("Attack Point is missing.");
            return;
        }

        canAttack = false;

        // Uses the same ChopWood animation used by interaction
        if (animator != null)
        {
            animator.SetTrigger("ChopWood");
        }

        if (audioSource != null && swordSwingSound != null)
        {
            audioSource.PlayOneShot(swordSwingSound);
        }

        int damage;

        if (equippedWeapon == swordItem)
        {
            damage = swordDamage;
        }
        else
        {
            damage = axeDamage;
        }

        Collider[] hits = Physics.OverlapSphere(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        foreach (Collider hit in hits)
        {
            BearHealth bear = hit.GetComponentInParent<BearHealth>();

            if (bear != null)
            {
                bear.TakeDamage(damage);
                Debug.Log("Bear took " + damage + " damage.");
                break;
            }
        }

        StartCoroutine(AttackCooldownRoutine());
    }

    private IEnumerator AttackCooldownRoutine()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(
                attackPoint.position,
                attackRange
            );
        }
    }
}