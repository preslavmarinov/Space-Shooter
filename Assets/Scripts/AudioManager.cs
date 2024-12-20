using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip homeClip;
    public AudioClip gameClip;
    private static AudioManager instance;
    private bool isMuted = false;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<AudioManager>();
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

    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        this.PlayAudioScene(sceneName);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        this.PlayAudioScene(scene.name);
    }

    public void PlayAudioScene(string sceneName)
    {
        if (this.isMuted) return;

        AudioClip currentClip = null;

        if (sceneName == "HomeScene")
        {
            currentClip = this.homeClip;
        }
        else if (sceneName == "GameScene")
        {
            currentClip = this.gameClip;
        }

        if (this.audioSource.clip != currentClip)
        {
            this.audioSource.clip = currentClip;
            this.audioSource.Play();
        }
    }

    public void ToggleMute()
    {
        this.isMuted = !this.isMuted;

        if (this.isMuted)
        {
            this.audioSource.Stop();
        }
        else
        {
            this.audioSource.Play();
        }
    }

    public void StartAudio()
    {
        if (this.isPlaying() || this.isMuted) return; 
        
        this.audioSource.Play();
        
    }

    public void StopAudio()
    {
        if (!this.isPlaying()) return;

        this.audioSource.Stop();
        
    }

    public bool isPlaying()
    {
        return this.audioSource.isPlaying;
    }


}
