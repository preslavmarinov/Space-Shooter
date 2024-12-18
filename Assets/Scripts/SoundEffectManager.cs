using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    private static SoundEffectManager instance;
    private bool soundEffectsMuted = false;

    public AudioSource audioSource;
    public AudioClip laserClip;
    public AudioClip asteroidDestroyClip;
    public AudioClip rocketDestroyClip;

    public static SoundEffectManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<SoundEffectManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayLaserSound()
    {
        if (this.laserClip != null && !this.soundEffectsMuted)
        {
            this.audioSource.PlayOneShot(this.laserClip);
        }
    }

    public void PlayAsteroidDestroySound()
    {
        if (this.asteroidDestroyClip != null && !this.soundEffectsMuted)
        {
            this.audioSource.PlayOneShot(this.asteroidDestroyClip);
        }
    }
    public void PlayRocketDestroySound()
    {
        if (this.rocketDestroyClip != null && !this.soundEffectsMuted)
        {
            this.audioSource.PlayOneShot(this.rocketDestroyClip);
        }
    }

    public void ToggleSoundEffects()
    {
        this.soundEffectsMuted = !this.soundEffectsMuted;
    }

    public bool AreSoundEffectsMuted()
    {
        return this.soundEffectsMuted;
    }
}
