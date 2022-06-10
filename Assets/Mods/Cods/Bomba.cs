using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("mao1") || other.gameObject.CompareTag("mao2")) 
        {
            Mao1movi.morrer = 1;
            Mao2movi.morrer = 1;
        }
    }
}
