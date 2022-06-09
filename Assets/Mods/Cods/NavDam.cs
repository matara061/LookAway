using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavDam : MonoBehaviour
{
    public MinionNav nav;
    public int lives = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 0)
        {
            Destroy(gameObject, 4);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Soco") || collision.gameObject.CompareTag("Tiro"))
        {
            lives--;
            Debug.Log("Dano");
        }
    }
}
