using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour, IDamagable
{
    [SerializeField] float attackDamage;
    [SerializeField] float attackSpeed;
    [SerializeField] float attackDistance;
    [SerializeField] float moveSpeed;
    [SerializeField] float health;
    [SerializeField] float playerDetectRadius;
    [Space(10), SerializeField] bool isDead;
    [SerializeField] bool isAttacking;
    [SerializeField] bool hasTarget;
    [SerializeField] Transform target;

    private Animator animator;
    private NavMeshAgent navMeshAgent;

    public void Damage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        navMeshAgent.SetDestination(transform.position);

        var collider = GetComponent<Collider>();
        collider.enabled = false;

        animator.SetFloat("WalkSpeed", 0);
        animator.SetBool("Die", true);
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;

        navMeshAgent.Warp(transform.position);
    }

    void Update()
    {
        if (!isDead)
        {
            if (!hasTarget)
            {
                var collisions = Physics.OverlapSphere(transform.position, playerDetectRadius);

                foreach (var objectTransform in collisions)
                {
                    if (objectTransform.CompareTag("Player"))
                    {
                        target = objectTransform.transform;
                        MoveToPlayer();
                        hasTarget = true;
                    }
                }
            }
            else if (hasTarget)
            {
                if (Vector3.Distance(transform.position, target.position) < attackDistance)
                {
                    //Attack
                    Attack();
                }
                else
                {
                    if (isAttacking) isAttacking = false;
                    navMeshAgent.SetDestination(target.position);
                }
            }
        }
    }

    private void Attack()
    {
        animator.SetFloat("WalkSpeed", 0);

        isAttacking = true;
        animator.SetBool("Attacking", true);
        //TODO: Implement player damage


        isAttacking = false;
        animator.SetBool("Attacking", false);

    }

    private void MoveToPlayer()
    {
        animator.SetFloat("WalkSpeed", navMeshAgent.speed);
        navMeshAgent.SetDestination(target.position);
    }
}
