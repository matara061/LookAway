using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAinimigoAkira : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent inimigo;
    public Transform ponto;
    public Animator anim;


    public float LookRadius = 20f;
    public float LookAttack = 5f;

    void Start()
    {
        inimigo = GetComponent<NavMeshAgent>();
        //ponto = GameObject.Find("unitychan Phisical").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(ponto.position, transform.position);


        if (Distance <= LookRadius)
        {
            inimigo.SetDestination(ponto.position);
            anim.SetBool("attack", false);
            anim.SetBool("player_fo", false);
            anim.SetBool("player_al", true);

        }
        if (Distance <= LookAttack)
        {
            FaceTarget();
            inimigo.SetDestination(ponto.position);
            anim.SetBool("player_fo", false);
            anim.SetBool("player_al", false);
            anim.SetBool("attack", true);

        }

    }

    void FaceTarget()
    {
        Vector3 direction = (ponto.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, LookRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, LookAttack);
    }
}
