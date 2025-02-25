using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaoDamage : MonoBehaviour
{
    public int lives = 10;
    public CaoIA cao;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 0)
        {
            cao.Dead();
            Destroy(gameObject, 4);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Soco") || collision.gameObject.CompareTag("Tiro"))
        {
            lives--;
            cao.Damage();
            Debug.Log("Dano");
        }
    }

    public void ExplosionDamage()
    {
        lives = -1;
    }
}
