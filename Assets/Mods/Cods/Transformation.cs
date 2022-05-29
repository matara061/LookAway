using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformation : MonoBehaviour
{


    [SerializeField] private Material material;
    [SerializeField] private Material material1;

    Renderer rend;

    public float valor = 2f;
    public GameObject Uni;
     //public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

rend=GetComponent<Renderer>();
//rend.enabled = false;
rend.material = material;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Time());
            //anim.Play("Fogo");
 
        }
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(0.5f);
            rend.enabled=true;
            rend.material = material1;
        Uni.transform.localScale *= valor;

        yield return new WaitForSeconds(15f);

        Uni.transform.localScale /= valor;
        material.color = Color.white;
        rend.material = material;

    }


}