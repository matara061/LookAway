using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{

    public Text troca;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // trocar dps para colidir com algo 
        {
            TextChange();
        }
    }

    private void TextChange()
    {
        troca.text = "Rank 1"; // criar variavel para o numero 
    }
}
