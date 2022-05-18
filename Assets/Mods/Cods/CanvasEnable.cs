using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasEnable : MonoBehaviour
{
    //Dessa forma o unity vai buscar a refer�ncia dentro do objeto que est� com o c�digo
    public Canvas Canva;
    void Start()
    {
        //Chama frequentemente essa fun��o, dessa forma o Canvas fica sempre desativado
        Canva.enabled = false;
    }

    void Update()
    {
        // faz com que o tempo do IEnumerator ocorra de maneira correta
        StartCoroutine(Freeze());
    }
    void OnTriggerEnter(Collider other)

    {
        // Caso o Player entre dentro da �rea demarcada, o Canvas � ativado
        if (other.gameObject.tag == "Player")
        {
            Canva.enabled = true;
            Debug.Log("Ativado");
        }
    }

    //Independente de quantas vezes a tecla � pressionada, o canvas s� � desativado ap�s 4 segundos.
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
