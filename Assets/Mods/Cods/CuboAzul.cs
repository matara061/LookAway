using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboAzul : MonoBehaviour
{
    public JogoGenius genius;
    public static int des = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (des == 0)
        {
            return;
        }
        else if (des == 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            genius.cubo = 2;
            genius.esperar = 1;
        }
    }
}
