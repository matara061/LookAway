using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efeito1 : MonoBehaviour
{

    public GameObject Effect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Effect")
        {
            //Inst?cia o efeito
            Instantiate(Effect, transform.position, transform.rotation);

        }
    }
}