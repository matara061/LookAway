using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private Shrine shrine;
    [SerializeField]
    private ShrineOut ShrineOut;
    public Text troca;

    public int nivel = 1;
    public int level = 0;

    public static Rank rankInstance;
    // Start is called before the first frame update
    void Start()
    {
        // item = GameObject.Find("item(teste)").GetComponent<Item>();
        achar();
        shrine = GameObject.Find("portal").GetComponent<Shrine>();
        ShrineOut = GameObject.Find("portalOut").GetComponent<ShrineOut>();
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

        Receber();
        if (shrine.muda == true)
        {
            achar();
            ShrineOut = GameObject.Find("portalOut").GetComponent<ShrineOut>();
            shrine.muda = false;
        }
        if(ShrineOut.sair)
        {
            shrine = GameObject.Find("portal" + level).GetComponent<Shrine>();
            ShrineOut.sair = false;
        }
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
            level++;
        }
    }
}
