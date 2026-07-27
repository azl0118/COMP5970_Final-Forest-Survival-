using UnityEngine;
using UnityEngine.AI;

public class BearAI : MonoBehaviour
{
    public Transform player;

    [Header("Detection")]
    public float detectionRange = 15f;
    public float attackRange = 2f;
    public float loseInterestRange = 25f;

    [Header("Movement")]
    public float moveSpeed = 1f;
    public float patrolRadius = 10f;
    public float patrolWaitTime = 3f;

    [Header("Combat")]
    public int damage = 20;
    public float attackCooldown = 1.5f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip attackSound;

    private NavMeshAgent agent;
    private Animator animator;

    private PlayerHealth playerHealth;

    private float patrolTimer;
    private float nextAttackTime;

    private bool attacking;


    private enum State
    {
        Patrol,
        Chase,
        Attack
    }

    private State currentState = State.Patrol;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        if (player != null)
        {
            playerHealth = player.GetComponentInParent<PlayerHealth>();

            if (playerHealth == null)
            {
                playerHealth = player.GetComponentInChildren<PlayerHealth>();
            }
        }

        if (playerHealth == null)
        {
            Debug.LogError("BearAI could not find PlayerHealth.");
        }

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        agent.speed = moveSpeed;

        SetIdle();
        ChoosePatrolPoint();
    }

    void Update()
    {
        if (player == null)
            return;


        float distance = Vector3.Distance(
            transform.position,
            player.position
        );


        switch (currentState)
        {
            case State.Patrol:

                Patrol();

                if (distance <= detectionRange)
                {
                    currentState = State.Chase;
                }

                break;


            case State.Chase:

                ChasePlayer(distance);

                break;


            case State.Attack:

                AttackPlayer(distance);

                break;
        }
    }


    // patrols an area
    void Patrol()
    {
        agent.isStopped = false;

        float speed = agent.velocity.magnitude;


        if (speed > 0.15f)
        {
            SetWalk();
        }
        else
        {
            SetIdle();
        }


        patrolTimer += Time.deltaTime;


        if (!agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance + 0.1f)
        {
            agent.isStopped = true;
            agent.ResetPath();

            SetIdle();


            if (patrolTimer >= patrolWaitTime)
            {
                agent.isStopped = false;

                ChoosePatrolPoint();

                patrolTimer = 0;
            }
        }
    }


    // chases after player, stops if out of range
    void ChasePlayer(float distance)
    {
        agent.isStopped = false;

        SetWalk();

        agent.SetDestination(player.position);


        if (distance <= attackRange)
        {
            currentState = State.Attack;
        }


        if (distance > loseInterestRange)
        {
            currentState = State.Patrol;
            ChoosePatrolPoint();
        }
    }


    //attacks player
    void AttackPlayer(float distance)
    {
        agent.isStopped = true;

        SetIdle();


        Vector3 lookDirection = player.position - transform.position;
        lookDirection.y = 0;


        if (lookDirection != Vector3.zero)
        {
            transform.rotation =
                Quaternion.LookRotation(lookDirection);
        }


        if (!attacking &&
            Time.time >= nextAttackTime)
        {
            StartAttack();
        }


        if (distance > attackRange)
        {
            StopAttack();

            agent.isStopped = false;

            currentState = State.Chase;
        }
    }


    // begins attacking
    void StartAttack()
    {
        attacking = true;

        nextAttackTime = Time.time + attackCooldown;

        animator.SetBool("Walk Forward", false);
        animator.SetBool("Combat Idle", false);
        animator.SetBool("Attack3", true);

        if (audioSource != null && attackSound != null)
        {
            audioSource.PlayOneShot(attackSound);
        }

        // Damage about halfway through the attack animation
        Invoke(nameof(DealDamage), 0.5f);

        // Reset after the animation finishes
        Invoke(nameof(AttackFinished), 1.2f);
    }

    //ANIMATION EVENT
    public void DealDamage()
    {
        if (playerHealth == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange + 0.5f)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Bear attacked player!");
        }
    }

    public void AttackFinished()
    {
        animator.SetBool("Attack3", false);
        attacking = false;
    }

    // Stops Attacking
    void StopAttack()
    {
        animator.SetBool("Attack3", false);

        attacking = false;
    }


    // continues walking
    void SetWalk()
    {
        animator.SetBool("Walk Forward", true);
        animator.SetBool("Combat Idle", false);
        animator.SetBool("Attack3", false);
    }


    // finds combat idle 
    void SetIdle()
    {
        animator.SetBool("Walk Forward", false);
        animator.SetBool("Combat Idle", true);
        animator.SetBool("Attack3", false);
    }


    // patrol area
    void ChoosePatrolPoint()
    {
        Vector3 randomPoint =
            Random.insideUnitSphere * patrolRadius;


        randomPoint += transform.position;


        NavMeshHit hit;


        if (NavMesh.SamplePosition(
            randomPoint,
            out hit,
            patrolRadius,
            NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}