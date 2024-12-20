using UnityEngine;
using UnityEngine.UI;

public class AudioToggleButton : MonoBehaviour
{
    public Button audioButton;
    public Sprite audioOnSprite;
    public Sprite audioOffSprite;

    private AudioManager audioManager;

    void Start()
    {
        this.audioManager = FindFirstObjectByType<AudioManager>();
        this.UpdateButtonIcon();
        this.audioButton.onClick.AddListener(ToggleAudio);
    }

    private void ToggleAudio()
    {
        this.audioManager.ToggleMute();
        this.UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (!this.audioManager.isPlaying())
        {
            this.audioButton.GetComponentInChildren<Image>().sprite = this.audioOffSprite;
        }
        else
        {
            this.audioButton.GetComponentInChildren<Image>().sprite = this.audioOnSprite;
        }
    }
}
