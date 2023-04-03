using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public LayerMask playerLayer;
    public Player player;
    private bool dead;
    public float Health = 1;
    public float vision;
    public float attackRadius;
    public float attackDamage;
    NavMeshAgent agent;
    public Animator animator;
    bool run = true;
    public AudioSource AudioSource;
    public ParticleSystem muzzleFlash;
    public RuntimeAnimatorController animatorDeath;
    public GameObject killScoreGO;
    //attacking player
    public Camera enemyCamera;
    public float distance;
    public float checkSpaceDistance;
    public GameObject playerGO;
    public float checkDelay;
    public float attackDelay;
    public float counter;
    bool allowToCheckPlayer = true;
    private float ammo = 10f;
    private void Start()
    {
        tag = "Enemy";
        agent = GetComponent<NavMeshAgent>();
    }
    public void CheckAttack()
    {
        if (Physics.CheckSphere(transform.position, attackRadius, playerLayer) && ammo != 0)
        {
            CheckPlayer();
        }
    }
    private void ChasePlayer()
    {
        if (Physics.CheckSphere(transform.position, vision, playerLayer))
        {
            if(run == true)
            {
                agent.SetDestination(player.transform.position);
                animator.Play("Move");
            }
        }
    }
    public void AttackPlayer()
    {
        counter = 0;
        AudioSource.Play();
        muzzleFlash.Play();
        animator.Play("Attack");
        if (Physics.CheckSphere(transform.position, attackRadius, playerLayer))
        {
            RaycastHit hit;
            ammo -= 1f;
            if (Physics.Raycast(enemyCamera.transform.position, enemyCamera.transform.forward, out hit, distance))
            {
                if (hit.transform.tag.Equals("Player"))
                {
                    if (Random.value < 0.3f)
                    {
                        player.Hurt(attackDamage);
                    }
                }
            }
        }
    }
    public void Update()
    {
        if (dead == false)
        {
            ChasePlayer();
            CheckAttack();
        }
        if(ammo == 0)
        {
            animator.Play("Reload");
            Invoke("makeAmmoFull", 2);
        }
    }

    public void Hurt(float Damage)
    {
        Health = Health - Damage;
        if (Health <= 0)
        {
            dead = true;
            agent.SetDestination(transform.position);
            animator.runtimeAnimatorController = animatorDeath;
        }
    }
    public void CheckPlayer()
    {
        if(allowToCheckPlayer == true)
        {
            counter += 0.02f;
            if (counter >= attackDelay)
            {
                counter = 0f;
                transform.LookAt(playerGO.transform.position);
                RaycastHit hit;
                if (Physics.Raycast(enemyCamera.transform.position, enemyCamera.transform.forward, out hit, checkSpaceDistance))
                {
                    if (hit.transform.tag.Equals("Player"))
                    {
                        allowToCheckPlayer = false;
                        counter += 0.02f;
                        AttackPlayer();
                        run = false;
                        Invoke("allowToCheck", checkDelay);
                    }
                    else
                    {
                        run = true;
                    }
                }
            }
        }
    }
    public void allowToCheck()
    {
        allowToCheckPlayer = true;
    }
    public void killScorePlus()
    {
        killScoreGO.GetComponent<KillScore>().scorePlus();
    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
    public void makeAmmoFull()
    {
        ammo = 10f;
    }
}