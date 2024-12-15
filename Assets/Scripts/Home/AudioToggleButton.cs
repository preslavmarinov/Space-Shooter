using UnityEngine;
using UnityEngine.UI;

public class AudioToggleButton : MonoBehaviour
{
    public Button audioButton;
    public Sprite audioOnSprite;
    public Sprite audioOffSprite;

    private AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();

        UpdateButtonIcon(true);
        audioButton.onClick.AddListener(ToggleAudio);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ToggleAudio()
    {
        audioManager.ToggleMute();
        UpdateButtonIcon(false);
    }

    private void UpdateButtonIcon(bool initialUpdate)
    {
        if (!audioManager.isPlaying() && !initialUpdate)
        {
            audioButton.GetComponentInChildren<Image>().sprite = audioOffSprite;
        }
        else
        {
            audioButton.GetComponentInChildren<Image>().sprite = audioOnSprite;
        }
    }
}
