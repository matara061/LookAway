using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvocarBomba : MonoBehaviour
{
    public GameObject bomba;
    public GameObject caixa;
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
       if(other.gameObject.CompareTag("Caixa"))
       {
            Debug.Log("nasceu");
            Instantiate(bomba, new Vector3(1.1f, 4.75f, -2), Quaternion.identity);
            Destroy(caixa);
       }
    }

}
