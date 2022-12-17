using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject overScreen;
    public GameObject pauseMenu;
    void Start()
    {
        isGameOver = false;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (isGameOver)
        {
            // Time.timeScale = 0;
            overScreen.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void RetryGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
