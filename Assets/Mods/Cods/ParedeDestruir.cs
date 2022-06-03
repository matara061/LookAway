using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeDestruir : MonoBehaviour
{
    public static int des=0;
    public GameObject efeito;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (des == 0) 
        {
            return;
        }
        else if (des == 1) 
        {
            Instantiate(efeito, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
