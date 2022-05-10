using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //efeito
    public GameObject Effect;

    //Verifica os collider's. Se for compativel com a tag colocada, interação é verdadeira
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Caixa")
        {
            //Instância o efeito
            Instantiate(Effect, transform.position, transform.rotation);

            // add som aqui

            //Destroi o objeto. animação quando soubermos pode entrar embaixo 
            Destroy(gameObject);
        }
    }
}
