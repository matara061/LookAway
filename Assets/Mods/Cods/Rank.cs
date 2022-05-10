using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    public Item item;
    public Text troca;

    public int nivel = 1;

    public static Rank rankInstance;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (rankInstance == null)
        {
            rankInstance = this;
        }
        else
            DestroyObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.GetMouseButton(0)) // trocar dps para colidir com algo 
       // {
       //     TextChange();
       // }
       if (item.receb)
        {
            TextChange();
            Debug.Log("aquitb");
            item.receb = false;
            nivel += 1;
        }
    }

    private void TextChange()
    {
        troca.text = "Rank " + nivel.ToString(); // criar variavel para o numero 
    }
}
