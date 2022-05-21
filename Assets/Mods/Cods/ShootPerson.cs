using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPerson : MonoBehaviour
{
    public GameObject shoot;
    public Transform Target;
    public GameObject Efeito;
    Rigidbody rb;

    public float FireRate;
    float nextTimeToFire = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                Shoot();
            }
        }
        
    }

    void Shoot()
    {
        Instantiate(Efeito, Target.transform.position, Target.transform.rotation);
        Rigidbody rb = Instantiate(shoot, Target.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.forward * 32f, ForceMode.Acceleration);
        //rb.AddForce(transform.forward * 32f, ForceMode.VelocityChange);
        rb.AddForce(transform.up * 1, ForceMode.Impulse);
    }
}
