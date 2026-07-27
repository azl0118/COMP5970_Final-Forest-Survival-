using UnityEngine;
using UnityEngine.AI;

public class BearHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float destroyDelay = 3f;

    private int currentHealth;
    private bool isDead;

    private Animator animator;
    private NavMeshAgent agent;
    private BearAI bearAI;

    private void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        bearAI = GetComponent<BearAI>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        Debug.Log("Bear Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else if (animator != null)
        {
            animator.SetTrigger("Hit Front");
        }
    }

    private void Die()
    {
        isDead = true;

        if (bearAI != null)
        {
            bearAI.enabled = false;
        }

        if (agent != null && agent.isOnNavMesh)
        {
            agent.isStopped = true;
        }

        if (animator != null)
        {
            animator.SetTrigger("Death");
        }

        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider bearCollider in colliders)
        {
            bearCollider.enabled = false;
        }

        GameManager.Instance.PlayerWon();
        Destroy(gameObject, destroyDelay);
    }
}