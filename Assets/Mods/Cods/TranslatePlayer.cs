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
        // ainda não tem o aúdio mananger
        // FindObjectOfType<AudioManager2>().Play("Coracao");
    }

    // Enumerator é para a função couratine, que faz com que o sistema tenha a função de espera e pausa.
    IEnumerator Pickup(Collider player)
    {
        // Podemos utilizar a função abaixo para o efeito instanciar no game object escolhido ~ no caso, o player.
        GameObject clone = Instantiate(pickupEffect, transform.position, transform.rotation);

        // para a hierarquia
        clone.transform.parent = player.transform;

        //Efeito
        player.transform.Translate(0, 20, 0);

        // no momento, não há necessidade disso
        yield return new WaitForSeconds(0.1f);

        //Destruir o clone
        Destroy(clone.gameObject, timetoDestroy);

    }
}
