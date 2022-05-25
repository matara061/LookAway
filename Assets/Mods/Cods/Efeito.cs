using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efeito  : MonoBehaviour
{

    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Instancia o efeito
        Instantiate(Effect, transform.position, transform.rotation);
    }

}
