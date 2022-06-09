using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pular : MonoBehaviour
{

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pula")
        {
            //Debug.Log("pula");
   
            rb.AddForce(transform.up * 80f, ForceMode.VelocityChange);
        }
    }
}
