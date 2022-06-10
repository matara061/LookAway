using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mao1movi : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Animator anima;
    public Transform player;
    public Transform proteger;
    public Mao2movi mao2;
    public int trocar2;
    static public int morrer;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anima = GetComponent<Animator>();
        trocar2 = 1;
        agent.speed = 7;
        morrer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (trocar2 == 0)
        {
            agent.SetDestination(player.position);
            anima.SetBool("Ir", true);
        }
        if (morrer == 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anima.SetBool("Atacar", true);
            agent.speed = 0;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(5f);
        Trocar();
    }
    public void Trocar() 
    {
        anima.SetBool("Ir", false);
        trocar2 = 1;
        anima.SetBool("Proteger", true);
        anima.SetBool("Atacar", false);
        agent.SetDestination(proteger.position);
        agent.speed = 7;
        mao2.trocar1 = 0;
    }
}
