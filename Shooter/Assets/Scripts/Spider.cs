using System;
using System.Collections;
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

    [Space(10)]
    [SerializeField] AudioClip[] attackHitSounds;
    [SerializeField] AudioClip[] woundedSounds;
    [SerializeField] AudioClip[] deathSounds;

    [Space(10), SerializeField] bool isDead;
    [SerializeField] bool isAttacking;
    [SerializeField] bool hasTarget;
    [SerializeField] Transform target;

    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private AudioSource _audioSrc;

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
        if (isAttacking)
        {
            StopCoroutine("Attack");
        }
        isDead = true;

        _navMeshAgent.SetDestination(transform.position);

        var collider = GetComponent<Collider>();
        collider.enabled = false;

        _animator.SetFloat("WalkSpeed", 0);
        _animator.SetBool("Die", true);
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = moveSpeed;
        _audioSrc = GetComponent<AudioSource>();

        _navMeshAgent.Warp(transform.position);
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
            else if (hasTarget && !isAttacking)
            {
                if (Vector3.Distance(transform.position, target.position) < attackDistance)
                {
                    //Attack
                    if (!isAttacking)
                        StartCoroutine("Attack");
                    else
                        return;
                }
                else
                {
                    MoveToPlayer();
                }
            }
        }
    }

    private IEnumerator Attack()
    {
        _animator.SetFloat("WalkSpeed", 0);

        isAttacking = true;
        _animator.SetBool("Attacking", true);

        yield return new WaitForSeconds(.5f);

        if (Vector3.Distance(transform.position, target.position) < attackDistance)
        {
            var player = target.GetComponentInParent<PlayerHealth>();
            player.Damage(attackDamage);
            PlayHitSound();
        }

        yield return new WaitForSeconds(.5f);

        _animator.SetBool("Attacking", false);
        isAttacking = false;
    }

    private void PlayHitSound()
    {
        var sndIndex = UnityEngine.Random.Range(0, attackHitSounds.Length);
        _audioSrc.clip = attackHitSounds[sndIndex];
        _audioSrc.Play();
    }

    private void MoveToPlayer()
    {
        _animator.SetFloat("WalkSpeed", _navMeshAgent.speed);
        _navMeshAgent.SetDestination(target.position);
    }
}
