using UnityEngine;

public class ResultPopup : MonoBehaviour
{
    public void OnEnable()
    {
        Time.timeScale = 0;
        SoundManager.Instance.StopSound(2);
        SoundManager.Instance.StopSound(3);
        SoundManager.Instance.StopSound(6);

    }

    public void OnDisable()
    {
        Time.timeScale = 1;

    }
}
