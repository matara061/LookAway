using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IADamage2 : MonoBehaviour
{
    public int lives = 10;
    public MagicShoot iastar;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("damage_001");
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 0)
        {
            iastar.Dead();
           anim.Play("dead");
            Destroy(gameObject, 4);
            Debug.Log("Morreu");
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            lives--;
            iastar.Damage();
            anim.Play("damage_001");
            Debug.Log("Toma dano");

        }
    }

    public void ExplosionDamage()
    {
        lives = -1;
        anim.Play("damage_001");
    }
}
