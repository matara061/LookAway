using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhosDeGelo : MonoBehaviour
{
    Rigidbody EspinhoDeGelo;
    // Start is called before the first frame update
    void Start()
    {
        EspinhoDeGelo = GetComponent<Rigidbody>();
        EspinhoDeGelo.constraints = RigidbodyConstraints.FreezePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "IA")
        {
            EspinhoDeGelo.constraints = RigidbodyConstraints.None;
        }
    }
}
