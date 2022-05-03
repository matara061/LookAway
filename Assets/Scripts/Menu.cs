using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            pause = true;
           // Time.timeScale = 0;
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }else
            if (Input.GetKeyDown(KeyCode.Escape) && pause)
        {
            SceneManager.UnloadScene("Menu");
            pause = false;
        }


    }

    public void StartGame()
    {
        // SceneManager.LoadScene("Land");
        SceneManager.UnloadScene("Menu");
       // Time.timeScale = 1;
        pause = false;
    }

    public void Options()
    {
        print("isso");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
