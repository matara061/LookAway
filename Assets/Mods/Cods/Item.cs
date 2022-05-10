using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool receb;
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.tag = "Item";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Verifica se a tag no colisor é igual a Enemy
        if (other.tag == "Player")
        {
            receb=true;
            Destroy(gameObject);
            Debug.Log("recebido");
        }
    }
}
