using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    //initialise navMesh and animator
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    bool isDead = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position); // calculate distance between the player and enemy
        Debug.Log(distance);

        if (distance < 30f && !isDead)
        {
            agent.SetDestination(target.position);
            agent.updatePosition = true;
            anim.SetBool("IsWalking", true); // if player is close to the enemy, start walking towards it
        }
        else
        {
            agent.updatePosition = false;
            anim.SetBool("IsWalking", false); // if not, stop walking
        }
    }

    public void EnemyDeathAnim()
    {

        isDead = true; // if the enemy is dead, play the death animation
        anim.SetTrigger("isDead");
    }
}
