using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HP : MonoBehaviour
{
    public Image HP1;
    public Image HP2;
    public Image HP3;
    public Image HP4;
    public Image HP5;
    public Image HP6;
    public Image HP7;

    public int Lifes = 7;
    // Start is called before the first frame update
    void Start()
    {
        HP1.enabled = false;
        HP2.enabled = false;
        HP3.enabled = false;
        HP4.enabled = false;
        HP5.enabled = false;
        HP6.enabled = false;
        HP7.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IA"))
        {
            Lifes--;
            Debug.Log("Danooo");
        }

        if(Lifes == 6)
        {
            HP1.enabled = true;

        }
        if (Lifes == 5)
        {
            HP2.enabled = true;
        }
        if (Lifes == 4)
        {
            HP3.enabled = true;
        }
        if (Lifes == 3)
        {
            HP4.enabled = true;
        }
        if (Lifes == 2)
        {
            HP5.enabled = true;
        }
        if (Lifes == 1)
        {
            HP6.enabled = true;
        }
        if (Lifes == 0)
        {
            HP7.enabled = true;
        }
        else
        {
            Debug.Log("Morreu");
        }
       


    }
}
