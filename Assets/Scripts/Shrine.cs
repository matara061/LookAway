using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shrine : MonoBehaviour
{
    public string ShrineName;
    public bool muda = false;
    [SerializeField]
    //private Rank rank;
    // Start is called before the first frame update
    void Start()
    {
      // rank = GameObject.Find("Canvas").GetComponent<Rank>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefsX.SetVector3("OldPlayerPosition", other.transform.position - other.transform.forward * 2);
            SceneManager.LoadScene(ShrineName);
            muda = true;
            //rank.achar();
        }
    }
}
