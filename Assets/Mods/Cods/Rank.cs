using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    [SerializeField]
    private Item item;
    private Shrine shrine;
    public Text troca;

    public int nivel = 1;

    public static Rank rankInstance;
    // Start is called before the first frame update
    void Start()
    {
        // item = GameObject.Find("item(teste)").GetComponent<Item>();
        achar();
        shrine = GameObject.Find("shrine").GetComponent<Shrine>();
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
        //item = GameObject.Find("item(teste)").GetComponent<Item>();

        // if (item.receb)
        // {
        //     TextChange();
        //     Debug.Log("aquitb");
        //     item.receb = false;
        //     nivel += 1;
        // }
        Receber();
      //  if (shrine.muda == true)
      //  {
      //      achar();
      //      shrine.muda = false;
      //  }
    }

    private void TextChange()
    {
        troca.text = "Rank " + nivel.ToString(); // criar variavel para o numero 
    }

    public void achar()
    {
        item = GameObject.Find("item(teste)").GetComponent<Item>();
    }

    private void Receber()
    {
        if (item.receb)
        {
            TextChange();
            Debug.Log("aquitb");
            item.receb = false;
            nivel += 1;
        }
    }
}
