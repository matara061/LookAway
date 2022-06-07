using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonIA : MonoBehaviour
{

    public NavMeshAgent agent;
    public Animator anim;
    public GameObject target;

    public Transform TargetShoot;
    public GameObject projetil;
    float nextTimeToFire = 2;
    public float FireRate;

    // public bool attack = false;

    public float flyRadius = 30f;
    public float lookRadius = 20f;
    public float lookattack = 5f;

    //Efeitos
    public GameObject Efeito;  
    public GameObject Efeito2;
    public GameObject Efeito3;

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

        //  if (distance <= lookattack)
        //  {
        //      FaceTarget();
        //      anim.SetBool("player_fo", false);
        //      anim.SetBool("player_al", false);
        //      anim.SetBool("attack", true);
        //    //  anim.Play("Basic Attack");
        //      
        //  }
        //  else
        if (distance <= lookRadius) // raio amarelo ataque de longe
        {
            FaceTarget();
            anim.SetBool("player_fo", false);
            agent.speed = 0;
            agent.acceleration = 0;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                anim.SetBool("attack", true);
                Shoot();
            }
        }
        else
            if (distance <= flyRadius) // raio azul apenas voar 
        {
            anim.SetBool("attack", false);
            // anim.SetBool("player_al", false);
            anim.SetBool("player_fo", true);
            agent.speed = 500;
            agent.acceleration = 100;
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
    }

    public void Damage()
    {
        anim.SetTrigger("hit");
    }

    public void Shoot()
    {
        //Instantiate(Efeito, TargetShoot.transform.position, TargetShoot.transform.rotation);
        Rigidbody rb = Instantiate(projetil, TargetShoot.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }
}
