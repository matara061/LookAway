using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossJoao : MonoBehaviour
{
    // Talvez um public Transform player para melhorar a perseguição
    public GameObject target;

    //public GameObject projetil; //Lembrete
    public NavMeshAgent agent;
    public Animator anim;
    public SkinnedMeshRenderer render;

    // Teste Para o Tiro da IA
    /*public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange; --Lembrete*/ // acaba aqui
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
        anim.SetFloat("Walk", agent.velocity.magnitude);

        // para verificar a visão do ataque. O numero é a Layer que o player se encontra 
        /*playerInSightRange = Physics.CheckSphere(transform.position, sightRange, 6);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, 6); --Lembrete*/

        //Estados para situações:
        // 1°: Caso o player esteja dentro do alcance de visão, mas não no de ataque, a IA deve persegui-lo.
        /*if (!playerInSightRange && !playerInAttackRange)  AttackState();
        if (playerInSightRange && !playerInAttackRange)  PursuitState(); -- Lembrete*/

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
        anim.SetBool("Hit2 0", false);
        //anim.Play("Hit2")
        //anim.SetBool("Damage", false);
        Debug.Log("Perseguindo");

        // Att Pet ~ o Valor Original é < 3. é aqui que a IA verifica a posição do jogador para começar a atacar
        if (Vector3.Distance(transform.position, target.transform.position) < 3)
        {
            state = States.atacking;

        }
    }

    void AttackState()
    {
        agent.isStopped = true;
        //anim.SetBool("Hit2 0", true);
        anim.Play("Hit2");
        //anim.SetBool("Damage", false);
        Debug.Log("atacando");
        //Olha a ped4ra ~ faz o projetil voar
        /*Debug.Log("atacando");
        Rigidbody rb = Instantiate(projetil, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse); --Lembrete*/

        //rb.AddForce(transform.up * 8f, ForceMode.Impulse);// ?

        //Instancia de um ponto, como se fosse bombas.
        //GameObject shoot = Instantiate(projetil, transform.position, transform.rotation);
        //shoot.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(velocidade, 0, 0));

        if (Vector3.Distance(transform.position, target.transform.position) > 4)
        {
            state = States.pursuit;

        }


    }

    void StoppedState()
    {
        agent.isStopped = true;
        anim.Play("Walk");
        //anim.SetBool("Hit2 0", false);
        //anim.SetBool("Damage", false);
    }

    void DeadState()
    {
        agent.isStopped = true;
        anim.SetBool("Hit2 0", false);
        anim.SetBool("Dead", true);
        //anim.SetBool("Damage", false);
    }

    void DamageState()
    {
        agent.isStopped = true;
        //anim.SetBool("Damage", true);
        anim.Play("Rage");
    }
}