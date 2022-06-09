using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionNav : MonoBehaviour
{

    public NavMeshAgent agent;
    public Animator anim;
    [SerializeField]
    GameObject target;

    public Transform TargetShoot;
    public GameObject projetil;

    float nextTimeToFire = 2;
    public float FireRate;

    // public bool attack = false;

    public float flyRadius = 60f;
    public float lookRadius = 30f;

    public GameObject Efeito;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        agent.stoppingDistance = lookRadius - 3;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);// distancia entre IA e o player

        if (distance <= lookRadius)
        {
            FaceTarget();
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                Efect();
                Shoot();
            }
        }else 
            if(distance <= flyRadius)
        {
            agent.SetDestination(target.transform.position);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void Shoot()
    {
        Rigidbody rb = Instantiate(projetil, TargetShoot.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 35f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }

    public void Efect()
    {
        Rigidbody rb = Instantiate(Efeito, TargetShoot.transform.position, TargetShoot.transform.rotation).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 35f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }

    private void OnDrawGizmosSelected() // circulos ao redor da IA (apenas visual)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, flyRadius);

    }

}
