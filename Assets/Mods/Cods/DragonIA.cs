using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonIA : MonoBehaviour
{

    public NavMeshAgent agent;
    public Animator anim;
    public GameObject target;

    // public bool attack = false;

    public float flyRadius = 30f;
    public float lookRadius = 20f;
    public float lookattack = 5f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);// distancia entre IA e o player

        if (distance <= lookattack)
        {
            FaceTarget();
            anim.SetBool("player_fo", false);
            anim.SetBool("player_al", false);
            anim.SetBool("attack", true);
          //  anim.Play("Basic Attack");
            
        }
        else
        if (distance <= lookRadius)
        {
            anim.SetBool("attack", false);
            anim.SetBool("player_fo", false);
            anim.SetBool("player_al", true);
           // anim.Play("Run");
            agent.SetDestination(target.transform.position);
        }else
            if(distance <= flyRadius)
        {
            anim.SetBool("attack", false);
            anim.SetBool("player_al", false);
            anim.SetBool("player_fo", true);
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, flyRadius);

    }

    public void Dead()
    {
        anim.SetBool("attack", false);
        anim.SetBool("player_fo", false);
        anim.SetBool("player_al", false);
        anim.SetTrigger("die");
        //anim.Play("die");
    }

    public void Damage()
    {
        anim.SetTrigger("hit");
       // anim.Play("Get Hit");
    }
}
