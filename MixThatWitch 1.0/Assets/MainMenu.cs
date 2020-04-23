using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        //Loads the next scene in the que
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        //Debug log to show that the quit button works in unity without building the game
        Debug.Log("QUIT!");
        //This quits the game 
        Application.Quit();
    }
}
