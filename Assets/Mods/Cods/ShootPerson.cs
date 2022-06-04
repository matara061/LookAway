using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPerson : MonoBehaviour
{
    public GameObject shoot;
    public Transform Target;
    public GameObject Efeito;
    public Transform ShootPoint;

    public DemonAttack demon;
    Rigidbody rb;
    [SerializeField]
   public GameObject prefab;
    public float speed = 30;

    public float FireRate = 1;
    float nextTimeToFire = 1;
    // Start is called before the first frame update
    void Start()
    {

       // prefab = Resources.Load("projetil") as GameObject;

       // rb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            
          
                nextTimeToFire = Time.time + FireRate;
            // GameObject projetil = Instantiate(prefab) as GameObject;
            //Instantiate(prefab);
            // prefab.transform.position = transform.position + Camera.main.transform.forward * 2;

            // Instantiate(prefab, Camera.main.transform.position, Camera.main.transform.rotation);
            // prefab.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Impulse);


            //  Rigidbody rb = prefab.GetComponent<Rigidbody>();
            Rigidbody rb = Instantiate(prefab, ShootPoint.position, ShootPoint.rotation).GetComponent<Rigidbody>();
            //rb.velocity = ShootPoint.forward * 40;

          //  prefab.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.forward * speed, transform.up * 10, ForceMode.Acceleration);
           // rb.AddForceAtPosition(Vector3.forward, -Camera.main.transform.position, ForceMode.Impulse);
           // rb.AddForceAtPosition(Vector3.forward, -Camera.main.transform.position, ForceMode.Acceleration);


            rb.AddRelativeForce(new Vector3(1,5,32), ForceMode.Impulse);
            //rb.AddForce(transform.forward * 32f, ForceMode.Acceleration);
            //rb.AddForce(transform.up * 3, ForceMode.Impulse);


        }
        
    }

    void Shoot()
    {
        Instantiate(Efeito, Target.transform.position, Target.transform.rotation);
        Rigidbody rb = Instantiate(shoot, Target.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
        rb.AddForce(transform.forward * 24f, ForceMode.Acceleration);
        //rb.AddForce(transform.forward * 32f, ForceMode.VelocityChange);
        rb.AddForce(transform.up * 1.5f, ForceMode.Impulse);
    }
}
