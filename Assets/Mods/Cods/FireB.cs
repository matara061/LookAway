using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireB : MonoBehaviour
{

    public GameObject Efeito;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Efeito, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}