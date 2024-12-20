using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public AudioResource EnemyHit;
    public AudioResource FarmDestroy;
    public AudioResource CountDown;
    public AudioResource Clock;
    public AudioResource Death;
    public AudioResource ScoreItem;
    public AudioResource BGM;


    public AudioSource[] audioSource;


    private static SoundManager instance;
    public static SoundManager Instance
    {
        get { return instance; }
    }
    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void EnemyHitSFX()
    {
        audioSource[0].resource = EnemyHit;
        audioSource[0].Play();
    }

    public void FarmDestroySFX()
    {
        audioSource[1].resource = FarmDestroy;
        audioSource[1].Play();
    }
    public void CountDownSFX()
    {
        audioSource[2].resource = CountDown;
        audioSource[2].Play();
    }
    public void ClockSFX()
    {
        audioSource[3].resource = Clock;
        audioSource[3].Play();
    }

    public void EnemyDeath()
    {
        audioSource[4].resource = Death;
        audioSource[4].Play();
    }
    public void ScoreItemSFX()
    {
        audioSource[5].resource = ScoreItem;
        audioSource[5].Play();
    }
    public void BGMPlayer()
    {
        audioSource[6].resource = BGM;
        audioSource[6].Play();
    }

    public void StopSound(int index)
    {
        if (index >= 0 && index < audioSource.Length)
        {
            audioSource[index].Stop();
            audioSource[index].clip = null;
        }
            
    }
}
