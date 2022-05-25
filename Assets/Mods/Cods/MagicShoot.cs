using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MagicShoot : MonoBehaviour
{

    // Talvez um public Transform player para melhorar a persegui豫o
    public GameObject target;
    public Transform TargetShoot;

    public GameObject projetil; //Lembrete
    public NavMeshAgent agent;
    public Animator anim;
    public SkinnedMeshRenderer render;

    // Teste Para o Tiro da IA
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange; // acaba aqui
    public bool allowInvoke = true;

    public GameObject Efeito;
    public GameObject Efeito2;
    public GameObject Efeito3;
    public float FireRate;
    float nextTimeToFire = 2;

    
    public float velocidade = 1000f;
    public int lives = 10;
    public MagicShoot iastar;

    public float lookRadius = 20f;
    public float lookattack = 5f;

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

    }

    //Só para ter certeza de que vai encontrar o player
    private void Awake()
    {
        //target = GameObject.Find("unitychan Phisical");
    }
    void Update()
    {
        StateMachine();
        anim.SetFloat("Velocidade", agent.velocity.magnitude);

        // para verificar a visão do ataque. O numero ?a Layer que o player se encontra 
       // playerInSightRange = Physics.CheckSphere(transform.position, sightRange, 6);
       // playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, 6);

        //Estados para situações:
        // 1? Caso o player esteja dentro do alcance de visão, mas não no de ataque, a IA deve persegui-lo.
        //if (!playerInSightRange && !playerInAttackRange) AttackState();
       // if (playerInSightRange && playerInAttackRange) PursuitState();

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
        anim.SetBool("damage_001", false);
        //Debug.Log("perseguindo");

        
        if (Vector3.Distance(transform.position, target.transform.position) < 30)
        {
            state = States.atacking;

        }
    }

    void AttackState()
    {
        agent.isStopped = true;
        anim.SetBool("attack_short_001", true);
        anim.Play("attack_short_001");
        anim.SetBool("damage_001", false);
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
        anim.SetBool("attack_short_001", false);
        anim.SetBool("damage_001", false);
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
        anim.SetBool("damage_001", true);
    }

    void Shoot()
    {
        Instantiate(Efeito, TargetShoot.transform.position, TargetShoot.transform.rotation);
        Rigidbody rb = Instantiate(projetil, TargetShoot.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);

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
        if (collision.gameObject.CompareTag("Tiro"))
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
