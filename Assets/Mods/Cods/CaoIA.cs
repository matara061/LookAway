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
        float distance = Vector3.Distance(target.transform.position, transform.position);// distancia entre IA e o player

        if(distance <= lookattack)
        {
            FaceTarget();
            anim.Play("attack1");
        }else
        if (distance <= lookRadius)
        {
            anim.Play("run");
            agent.SetDestination(target.transform.position);
        }
    }

    // rotacionar para estar sempre de frete para o player
    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected() // circulos ao redor da IA (apenas visual)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookattack);
    }

    public void Dead()
    {
        anim.Play("die");
    }

    public void Damage()
    {
        anim.Play("damege");
    }
}
