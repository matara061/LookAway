using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAcao : MonoBehaviour
{
    // Talvez um public Transform player para melhorar a persegui��o
    public GameObject target;

    
    public NavMeshAgent agent;
    public Animator anim;
    public SkinnedMeshRenderer render;

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

    //S� para ter certeza de que vai encontrar o player
    private void Awake()
    {
        //target = GameObject.Find("unitychan Phisical");
    }
    void Update()
    {
        StateMachine();
        anim.SetFloat("Velocidade", agent.velocity.magnitude);

        // para verificar a vis�o do ataque. O numero � a Layer que o player se encontra 
        /*playerInSightRange = Physics.CheckSphere(transform.position, sightRange, 6);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, 6); --Lembrete*/

        //Estados para situa��es:
        // 1�: Caso o player esteja dentro do alcance de vis�o, mas n�o no de ataque, a IA deve persegui-lo.
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
        anim.SetBool("Attack", false);
        anim.SetBool("Damage", false);
        Debug.Log("Perseguindo");

        // Att Pet ~ o Valor Original � < 3. � aqui que a IA verifica a posi��o do jogador para come�ar a atacar
        if (Vector3.Distance(transform.position, target.transform.position) < 3)
        {
            state = States.atacking;

        }
    }

    void AttackState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", true);
        anim.SetBool("Damage", false);
        Debug.Log("atacando");

        if (Vector3.Distance(transform.position, target.transform.position) > 4)
        {
            state = States.pursuit;

        }


    }

    void StoppedState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        anim.SetBool("Damage", false);
    }

    void DeadState()
    {
        agent.isStopped = true;
        anim.SetBool("Attack", false);
        anim.SetBool("Dead", true);
        anim.SetBool("Damage", false);
    }

    void DamageState()
    {
        agent.isStopped = true;
        anim.SetBool("Damage", true);
    }
}
