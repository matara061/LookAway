using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public bool pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause == false)
        {
            pause = true;
            Time.timeScale = 0;
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        }
    }

    public void StartGame()
    {
        // SceneManager.LoadScene("Land");
        pause = false;
        Time.timeScale = 1;
        SceneManager.UnloadScene("Menu");
    }

    public void Options()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
