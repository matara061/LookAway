using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeMinion: MonoBehaviour
{

    public NavMeshAgent agent;
    //public Animator anim;
    private GameObject target;
    public GameObject efeito;

    public float lookRadius = 20f;
    public float lookattack = 5f;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);// distancia entre IA e o player

        if (distance <= lookattack)
        {
            FaceTarget();
            Dead();
            //anim.Play("attack1");
        }
        else
        if (distance <= lookRadius)
        {
            //anim.Play("run");
            agent.SetDestination(target.transform.position);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookattack);
    }

    public void Dead()
    {
        //anim.Play("die");
        Instantiate(efeito, transform.position, transform.rotation);
        Destroy(gameObject, 2f);

    }

    public void Damage()
    {
       // anim.Play("damege");
    }
}