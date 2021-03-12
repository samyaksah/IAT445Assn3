using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    Animator anim;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        Debug.Log(distance);

        if (distance < 30f && !isDead)
        {
            agent.SetDestination(target.position);
            agent.updatePosition = true;
            anim.SetBool("IsWalking", true);
        }
        else
        {
            agent.updatePosition = false;
            anim.SetBool("IsWalking", false);
        }
    }

    public void EnemyDeathAnim()
    {

        isDead = true;
        anim.SetTrigger("isDead");
    }
}
