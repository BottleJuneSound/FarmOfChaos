using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("GameScene");

        }
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}
