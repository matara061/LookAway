using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShootPerson : MonoBehaviour
{
    public GameObject Efeito;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "IA")
       // {
            Instantiate(Efeito, transform.position, transform.rotation);
            Destroy(gameObject);
       // }
    }
}
