using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasEnable : MonoBehaviour
{
    //Dessa forma o unity vai buscar a referência dentro do objeto que está com o código
    public Canvas Canva;
    void Start()
    {
        //Chama frequentemente essa função, dessa forma o Canvas fica sempre desativado
        Canva.enabled = false;
    }

    void Update()
    {
        // faz com que o tempo do IEnumerator ocorra de maneira correta
        StartCoroutine(Freeze());
    }
    void OnTriggerEnter(Collider other)

    {
        // Caso o Player entre dentro da área demarcada, o Canvas é ativado
        if (other.gameObject.tag == "Player")
        {
            Canva.enabled = true;
            Debug.Log("Ativado");
        }
    }

    //Independente de quantas vezes a tecla é pressionada, o canvas só é desativado após 4 segundos.
    IEnumerator Freeze()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            yield return new WaitForSeconds(4f);
            Canva.enabled = false;
            Debug.Log("Desativado");
        }
    }
}
