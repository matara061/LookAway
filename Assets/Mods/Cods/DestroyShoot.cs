using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyShoot : MonoBehaviour
{

    public GameObject Efeito;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(Efeito, transform.position, transform.rotation);
            Destroy(gameObject, 4f);
        }
    }
}

