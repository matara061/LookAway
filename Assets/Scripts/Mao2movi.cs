using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mao2movi : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anima;
    public Transform player;
    public Transform proteger;
    public Mao1movi mao1;
    public int trocar1;
    static public int morrer;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anima = GetComponent<Animator>();
        trocar1=0;
        agent.speed = 7;
        morrer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (trocar1 == 0)
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
        trocar1 = 1;
        anima.SetBool("Proteger", true);
        anima.SetBool("Atacar", false);
        agent.SetDestination(proteger.position);
        agent.speed = 7;
        mao1.trocar2 = 0;
    }
}
