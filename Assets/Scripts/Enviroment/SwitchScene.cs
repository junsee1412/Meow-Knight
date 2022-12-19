using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneIndex < sceneCount)
            {
                NextScene(sceneIndex + 1);
            }
        }
    }
    void NextScene(int index)
    {
        ActiveLevel(index);
        SceneManager.LoadScene(index);
    }
    void ActiveLevel(int level)
    {
        if (level > PlayerPrefs.GetInt("Knight", 1))
        {
            PlayerPrefs.SetInt("Knight", level);
        }
        PlayerPrefs.GetInt("Knight", 1);
    }
}
