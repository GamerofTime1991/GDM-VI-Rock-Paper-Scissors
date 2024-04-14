using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("This button is working");
        Application.Quit();
    }

    public void PlayRandom()
    {
        int index = Random.Range(6, 9);
        SceneManager.LoadScene(index);
    }
}
