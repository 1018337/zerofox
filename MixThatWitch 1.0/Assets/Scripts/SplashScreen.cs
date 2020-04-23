using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public void MainMenu()
    {
        //Loads the next scene in the que
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
