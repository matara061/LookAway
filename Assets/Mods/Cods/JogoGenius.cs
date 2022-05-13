using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogoGenius : MonoBehaviour
{
    public int numero;
    public int cubo;
    public int esperar;
    int pontos=0;
    // Start is called before the first frame update
    void Start()
    {
        Aleatorio();
    }

    void Aleatorio() 
    {
        numero = Random.Range(1, 5);
        Debug.Log(numero);
        Debug.Log(pontos);
    }

    void FixedUpdate()
    {
        Pausa();
    }
    void Pausa() 
    {
        if (esperar == 1)
        {
            Resposta();
        }
        else if (esperar == 0) 
        {
            return;
        }
    }
    void Resposta() 
    {
        if (numero == cubo)
        {
            Debug.Log("Acertou");
            pontos = pontos + 1;
            Final();
        }
        else if (numero != cubo) 
        {
            Debug.Log("errou");
            pontos=0;
            Final();
        }
    }
    void Final() 
    {
        if (pontos == 5)
        {
            ParedeDestruir.des = 1;
            CuboAmarelo.des = 1;
            CuboAzul.des = 1;
            CuboVerde.des = 1;
            CuboRosa.des = 1;
            CuboVermelho.des = 1;
        }
        else
        {
            Aleatorio();
        }
        esperar = 0;
    }

    // Update is called once per frame
    
}
