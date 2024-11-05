using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public void Start()
    {
        SoundManager.Instance.BGMPlayer();

    }
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            SoundManager.Instance.StopSound(6);
            SceneManager.LoadScene("GameScene");

        }
    }

    public void QuitPressed()
    {
        Application.Quit();
    }
}
