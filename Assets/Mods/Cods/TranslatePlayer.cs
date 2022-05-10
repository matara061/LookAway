using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatePlayer : MonoBehaviour
{
    float timetoDestroy = 0.1f;
    public GameObject pickupEffect;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
            Destroy(gameObject, timetoDestroy);
        }
        // ainda n�o tem o a�dio mananger
        // FindObjectOfType<AudioManager2>().Play("Coracao");
    }

    // Enumerator � para a fun��o couratine, que faz com que o sistema tenha a fun��o de espera e pausa.
    IEnumerator Pickup(Collider player)
    {
        // Podemos utilizar a fun��o abaixo para o efeito instanciar no game object escolhido ~ no caso, o player.
        GameObject clone = Instantiate(pickupEffect, transform.position, transform.rotation);

        // para a hierarquia
        clone.transform.parent = player.transform;

        //Efeito
        player.transform.Translate(0, 20, 0);

        // no momento, n�o h� necessidade disso
        yield return new WaitForSeconds(0.1f);

        //Destruir o clone
        Destroy(clone.gameObject, timetoDestroy);

    }
}
