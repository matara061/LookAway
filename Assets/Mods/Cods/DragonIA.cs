using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragonIA : MonoBehaviour
{

    public NavMeshAgent agent;
    public Animator anim;
    public GameObject target;

    public DragonDam dam;

    public Transform TargetShoot;
    public GameObject projetil;
    public GameObject projetil2;
    public GameObject projetil3;
    float nextTimeToFire = 2;
    public float FireRate;

    // public bool attack = false;

    public float flyRadius = 30f;
    public float lookRadius = 55.4f;
    public float lookattack = 5f;

    //Efeitos
    public GameObject Efeito; // tiro bola de fogo
    public GameObject Efeito2; // tiro raio
    public GameObject Efeito3; // tiro de perto

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.stoppingDistance = lookRadius - 3;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);// distancia entre IA e o player


        if (distance <= lookattack) // raio vermelho tiro de perto
        {
            FaceTarget();
            anim.SetBool("player_fo", false);
            // anim.SetBool("player_al", false);
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                anim.SetBool("attack", true);
                Efect3();
                NearShoot();
            }
        }
        else
      if (distance <= lookRadius) // raio amarelo ataque de longe
        {
            anim.SetBool("player_fo", false);
            FaceTarget();
            if (dam.lives >= 10) // padrao de ataque mais da metade da vida 
            {
                if (Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1 / FireRate;
                   // FaceTarget();
                    anim.SetBool("attack", true);
                    Efect();
                    Shoot();
                }
            } else
                if (dam.lives < 10) // padrao de ataque menos da metade da vida 
            {
                if (Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time + 1 / FireRate;
                    anim.SetBool("attack", true);
                    Efect2();
                    Shoot2();
                }
            }
        }
        else
          if (distance <= flyRadius) // raio azul apenas voar 
        {
            anim.SetBool("attack", false);
            // anim.SetBool("player_al", false);
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
        // anim.SetBool("player_al", false);
        anim.SetTrigger("die");
    }

    public void Damage()
    {
        anim.SetTrigger("hit");
    }

    public void Shoot()
    {
        Rigidbody rb = Instantiate(projetil, TargetShoot.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }

    public void Efect()
    {
        Rigidbody rb = Instantiate(Efeito, TargetShoot.transform.position, TargetShoot.transform.rotation).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 40f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }

    public void Shoot2()
    {
        Rigidbody rb = Instantiate(projetil2, TargetShoot.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }

    public void Efect2()
    {
        Rigidbody rb = Instantiate(Efeito2, TargetShoot.transform.position, TargetShoot.transform.rotation).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }

    public void NearShoot()
    {
        Rigidbody rb = Instantiate(projetil3, TargetShoot.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }

    public void Efect3()
    {
        Rigidbody rb = Instantiate(Efeito3, TargetShoot.transform.position, TargetShoot.transform.rotation).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }
}
