using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alavanca : MonoBehaviour
{

    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Instância o efeito
            Instantiate(Effect, transform.position, transform.rotation);

            // add som aqui

            //Destroi o objeto. animação quando soubermos pode entrar embaixo 
            Destroy(gameObject);
        }
    }
}
