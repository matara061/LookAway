using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireB : MonoBehaviour
{

    public GameObject Efeito;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Tiro");
        // Instantiate(Efeito, transform.position, transform.rotation);
        Rigidbody rb = Instantiate(Efeito, target.transform.position, target.transform.rotation).GetComponent<Rigidbody>();
       // rb.AddForce(transform.forward * 24f, ForceMode.Impulse);
       // rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Efeito.transform.position = transform.position;
    }
}