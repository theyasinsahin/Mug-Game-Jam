using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void QuitGame()
    {
        Debug.Log("oyundan çýktýk");
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {

        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {

        SceneManager.LoadScene(4);
    }
}
