using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaoIA : MonoBehaviour
{

    public NavMeshAgent agent;
    public Animator anim;
    public GameObject target;

    public float lookRadius = 20f;
    public float lookattack = 5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if(distance <= lookattack)
        {
            anim.Play("attack1");
        }else
        if (distance <= lookRadius)
        {
            anim.Play("run");
            agent.SetDestination(target.transform.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookattack);
    }
}
