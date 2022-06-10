using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlEs : MonoBehaviour
{
    public MagicShoot mago;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EspinhosDeGelo>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mago.lives == 9) 
        {
            GetComponent<EspinhosDeGelo>().enabled = false;
        }
    }
}
