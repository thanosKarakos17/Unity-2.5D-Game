using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource src;
    public void playGame()
    {
        src.Play();
        //GAMEMANAGER.randomBoss();
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        src.Play();
        Application.Quit();
    }
}
