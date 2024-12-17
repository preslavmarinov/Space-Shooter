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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        PlayAudioScene(sceneName);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        PlayAudioScene(scene.name);
    }

    public void PlayAudioScene(string sceneName)
    {
        if (isMuted) return;

        AudioClip currentClip = null;

        if (sceneName == "HomeScene")
        {
            currentClip = homeClip;
        }
        else if (sceneName == "GameScene")
        {
            currentClip = gameClip;
        }

        if (audioSource.clip != currentClip)
        {
            audioSource.clip = currentClip;
            audioSource.Play();
        }
    }

    public void ToggleMute()
    {
        this.isMuted = !this.isMuted;

        if (this.isMuted)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }

    public void StartAudio()
    {
        if (this.isPlaying() || this.isMuted) return; 
        
        audioSource.Play();
        
    }

    public void StopAudio()
    {
        if (!this.isPlaying()) return;

        audioSource.Stop();
        
    }

    public bool isPlaying()
    {
        return audioSource.isPlaying;
    }


}
