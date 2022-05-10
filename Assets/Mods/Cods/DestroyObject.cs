using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //efeito
    public GameObject Effect;

    //Verifica os collider's. Se for compativel com a tag colocada, intera��o � verdadeira
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Caixa")
        {
            //Inst�ncia o efeito
            Instantiate(Effect, transform.position, transform.rotation);

            // add som aqui

            //Destroi o objeto. anima��o quando soubermos pode entrar embaixo 
            Destroy(gameObject);
        }
    }
}
