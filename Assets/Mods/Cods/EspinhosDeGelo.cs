using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhosDeGelo : MonoBehaviour
{
    public GameObject efeito;
   
    Rigidbody EspinhoDeGelo;

    //MeshRenderer mesh;
    

    // Start is called before the first frame update
    void Start()
    {
        EspinhoDeGelo = GetComponent<Rigidbody>();
        EspinhoDeGelo.constraints = RigidbodyConstraints.FreezePosition;
       // mesh.enabled = false;

       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "IA")
        {
           // mesh.enabled = true;
            EspinhoDeGelo.constraints = RigidbodyConstraints.None;
            StartCoroutine(Freeze());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Caixa")
        {
            Instantiate(efeito, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }

    IEnumerator Freeze()
    {
        yield return new WaitForSeconds(0.1f);
        EspinhoDeGelo.constraints = RigidbodyConstraints.FreezePositionX;
        EspinhoDeGelo.constraints = RigidbodyConstraints.FreezeRotationX;


    }
}

