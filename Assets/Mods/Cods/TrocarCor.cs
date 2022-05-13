using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrocarCor : MonoBehaviour
{
    public JogoGenius genius;
    public Material[] material;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled=true;
    }

    // Update is called once per frame
    void Update()
    {
        rend.material=material[genius.numero];
    }
}
