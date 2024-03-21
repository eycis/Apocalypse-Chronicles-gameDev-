using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;
    public FPSController fpsController;
    //public Animator animator;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    //for patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    //For Attacking
    public float timeBetweenAttacks = 3f;
    bool alreadyAttacked;
    //checking states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public float chaseSpeed;
    public float attackSpeed;
    public bool IsChasing;
    public Animator animator;
    public GameManager gameManager;
    public AudioSource attackAudioSource;
    public AudioClip attackSound;

    public void Awake()
    {
        enemy = GetComponent<NavMeshAgent>();

    }
    
    public void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GetComponent<NavMeshAgent>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        player = GameObject.Find("Player").transform;
        fpsController = GameObject.FindObjectOfType<FPSController>();
        
    }
    public void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) 
        {
            animator.SetBool("IsChasing", false);
            Patrolling();
            attackCount = 0;
        }

        if(playerInSightRange && !playerInAttackRange)
        {
            animator.SetBool("IsChasing", true);
            ChasePlayer();
            attackCount = 0;
        } 

        
        if(playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    public void Patrolling()
    {
        IsChasing = false;

        if (!walkPointSet) 
        {
            SearchWalkPoint();
        }

        if (walkPointSet)
        {
            enemy.SetDestination(walkPoint);
        } 
        
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if(distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    
        
    }

    public void ChasePlayer()
    {
        enemy.speed = chaseSpeed;

        if(!playerInAttackRange)
        {
            enemy.SetDestination(player.transform.position);
        }

    }

    public void AttackPlayer()
    {
        transform.LookAt(player);

        enemy.speed = attackSpeed;

        enemy.SetDestination(transform.position);

        if(!alreadyAttacked)
        {
            fpsController.IncreaseAttackCount();
            attackAudioSource.clip = attackSound;
            attackAudioSource.Play();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);       
        }
    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
        ChasePlayer();
    }
    public void SearchWalkPoint()
    {
        //calculating random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //check if the point is actually on the ground
        if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

}

