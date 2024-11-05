using UnityEngine;

public class ResultPopup : MonoBehaviour
{
    public void OnEnable()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void OnDisable()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
