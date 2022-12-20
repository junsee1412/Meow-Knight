using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject overScreen;
    public GameObject pauseMenu;
    public GameObject HandheldPanel;

    private bool pause;
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
            overScreen.SetActive(isGameOver);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        if (HandheldPanel != null)
        {
            DeviceInfo();
        }
    }
    void DeviceInfo()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            if (!isGameOver && !pause) HandheldPanel.SetActive(true);
        }
        else
        {
            HandheldPanel.SetActive(false);
        }
        // Debug.Log(SystemInfo.deviceType);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        pause = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(pause);
    }
    public void ResumeGame()
    {
        pause = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(pause);
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
