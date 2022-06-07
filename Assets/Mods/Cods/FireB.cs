using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireB : MonoBehaviour
{

    public GameObject Efeito;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Efeito, transform.position, transform.rotation);
    }
}