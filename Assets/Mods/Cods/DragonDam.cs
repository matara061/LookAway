using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonDam : MonoBehaviour
{
    public int lives = 20;
    public DragonIA dragon;
    public bool minions;
    // Start is called before the first frame update
    void Start()
    {
        minions = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 0)
        {
            dragon.Dead();
            Destroy(gameObject, 4);
        }else
            if(lives <= 10 && minions == false)
        {
            SceneManager.LoadScene("VentoMinions", LoadSceneMode.Additive);
            minions = true;
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
