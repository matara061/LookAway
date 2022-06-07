using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDam : MonoBehaviour
{
    public int lives = 20;
    public DragonIA dragon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 0)
        {
            dragon.Dead();
            Destroy(gameObject, 4);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Soco") || collision.gameObject.CompareTag("Tiro"))
        {
            lives--;
            dragon.Damage();
            Debug.Log("Dano");
        }
    }

    
}
