using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Choices"); //this will have the name of your main game scene
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions"); //this will have the name of your main game scene
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits"); //this will have the name of your main game scene
    }

}