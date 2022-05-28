using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    Animator anim;
    public MeshRenderer Mess;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Mess.enabled=false;
        anim = GetComponent<Animator>();
        Mess = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
           StartCoroutine(ola());
            anim.Play("Esfera icosaédrica|Transformation");
        }
    }

    IEnumerator ola(){
        Mess.enabled=true;

         yield return new WaitForSeconds(2f);

         Mess.enabled=false;
    }
}