using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController1 : MonoBehaviour
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
        SceneManager.LoadScene("Flowey Battle"); //this will have the name of your main game scene
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}