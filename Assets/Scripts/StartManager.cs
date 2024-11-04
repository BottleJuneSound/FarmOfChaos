using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("GameScene");

        }
    }

    public void StartPressed()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("GameScene");

        }
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}
