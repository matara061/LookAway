using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MagicShoot : MonoBehaviour
{

    //Perseguição
    public GameObject target;
    public Transform TargetShoot;
    public float velocidade = 1000f;

    public NavMeshAgent agent;
    public Animator anim;
    public SkinnedMeshRenderer render;
    public MagicShoot iastar;

    //  Tiro da IA
    public float sightRange, attackRange;
    public float FireRate;

    float nextTimeToFire = 2;
    public GameObject projetil;
    public float lookRadius = 20f;
    public float lookattack = 5f;
    //public bool playerInSightRange, playerInAttackRange; // acaba aqui
    //public bool allowInvoke = true;

    //Efeitos
    public GameObject Efeito;  // tiro
    public GameObject Efeito2; // dano
    public GameObject Efeito3; // dano

    //Habilidades
    
    public BoxCollider EspinhoDeGelo;

    //Vida
    public int lives = 10;


    public enum States
    {
        pursuit,
        atacking,
        stoped,
        dead,
        damage,
    }

    public States state;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = true;
        EspinhoDeGelo.enabled = false;
    }

    void Update()
    {
        StateMachine();
        anim.SetFloat("Velocidade", agent.velocity.magnitude);


        float distance = Vector3.Distance(target.transform.position, transform.position);// distancia entre IA e o player

        if (distance <= lookattack)
        {
            AttackState();
        }
        else
        if (distance <= lookRadius)
        {
            PursuitState();
        }


    }

    void StateMachine()
    {
        switch (state)
        {
            case States.pursuit:
                PursuitState();
                break;
            case States.atacking:
                AttackState();
                break;
            case States.stoped:
                StoppedState();
                break;
            case States.dead:
                DeadState();
                break;
            case States.damage:
                DamageState();
                break;
        }
    }

    void ReturnPursuit()
    {
        state = States.pursuit;

    }
    public void Damage()
    {
        state = States.damage;
        Invoke("ReturnPursuit", 1);
        StartCoroutine(ReturnDamage());
    }
    IEnumerator ReturnDamage()
    {
        for (int i = 0; i < 4; i++)
        {
            render.material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.05f);
            render.material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(0.05f);
        }

    }

    public void Dead()
    {
        state = States.dead;
    }



    void PursuitState()
    {
        agent.isStopped = false;
        agent.destination = target.transform.position;
        anim.SetBool("attack_short_001", false);
        //anim.SetBool("move_forward_fast", true);
        anim.SetBool("idle_combat", false);
        //anim.SetBool("damage_001", false);
        //Debug.Log("perseguindo");


        if (Vector3.Distance(transform.position, target.transform.position) < 30)
        {
            state = States.atacking;

        }
    }

    void AttackState()
    {
        agent.isStopped = true;
        //anim.SetBool("damage_001", false);
        //anim.SetBool("attack_short_001", true);
        //anim.SetBool("move_forward_fast", false);
         anim.Play("attack_short_001");

        // anim.Stop();


        //Debug.Log("atacando");

        if (Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / FireRate;
            Shoot();
        }

        if (Vector3.Distance(transform.position, target.transform.position) > 4)
        {
            state = States.pursuit;

        }



    }

    void StoppedState()
    {
        agent.isStopped = true;
        //anim.SetBool("attack_short_001", false);
        anim.SetBool("damage_001", false);
        //anim.SetBool("move_forward_fast", false);
        //anim.SetBool("idle_combat", true);

    }

    void DeadState()
    {
        //agent.isStopped = true;
        //anim.SetBool("Attack", false);
        anim.SetBool("dead", true);
        anim.SetBool("damage_001", false);
    }

    void DamageState()
    {
        agent.isStopped = true;
        //anim.SetBool("attack_short_001", false);
        anim.SetBool("damage_001", true);
    }

    void Shoot()
    {
        Instantiate(Efeito, TargetShoot.transform.position, TargetShoot.transform.rotation);
        Rigidbody rb = Instantiate(projetil, TargetShoot.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);

        if (lives == 9)
        {
            EspinhosDeGelo();
        }

        if (lives <= 2)
        {
            lives--;
            DamageState();
            anim.Play("damage_001");

            Debug.Log("Berserker");
            GameObject shoot = Instantiate(projetil, TargetShoot.transform.position, TargetShoot.transform.rotation);
            shoot.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(velocidade, 10, 10));
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);
            FireRate = 20f;
        }

    }

    void EspinhosDeGelo()
    {
        EspinhoDeGelo.enabled = true;
        Debug.Log("Descongelou");
    }

    private void OnTriggerEnter(Collider collider)//collider para saber quandoo boneco deve parar
    {
        if (collider.gameObject.tag == "Player")
        {
            state = States.stoped;
            InvokeRepeating("Shoot", 1.0f, 2.0f);//pra ele ficar repetindo o tiro enquanto parado
        }
    }
    private void OnTriggerExit(Collider collider)//comando para continuar a seguir e parar os tiros enquando parado
    {
        if (collider.gameObject.tag == "Player")
        {
            state = States.pursuit;
            CancelInvoke();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tiro") || collision.gameObject.CompareTag("Soco"))
        {
            lives--;
            Instantiate(Efeito2, transform.position, transform.rotation);
            iastar.Damage();
            anim.Play("damage_001");
            Debug.Log("Toma dano");

        }
        if (lives < 0)
        {
            iastar.Dead();
            Instantiate(Efeito3, TargetShoot.transform.position, TargetShoot.transform.rotation);
            anim.Play("dead");
            Destroy(gameObject, 4);
            Destroy(Efeito3, 4);
            Debug.Log("Morreu");
        }
    }




}
