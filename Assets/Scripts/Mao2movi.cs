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
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            anima.SetBool("Atacar", true);
            agent.speed = 0;
        }
    }
}
