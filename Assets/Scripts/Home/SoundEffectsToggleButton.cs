using UnityEngine;
using UnityEngine.UI;


public class SoundEffectsToggleButton : MonoBehaviour
{
    public Button soundButton;
    public Sprite soundEffectOnSprite;
    public Sprite soundEffectOffSprite;

    private SoundEffectManager soundEffectManager;

    void Start()
    {
        this.soundEffectManager = FindFirstObjectByType<SoundEffectManager>();
        this.UpdateButtonIcon();
        this.soundButton.onClick.AddListener(ToggleSoundEffects);
    }

    private void ToggleSoundEffects()
    {
        this.soundEffectManager.ToggleSoundEffects();
        this.UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (!this.soundEffectManager.AreSoundEffectsMuted())
        {
            this.soundButton.GetComponentInChildren<Image>().sprite = this.soundEffectOnSprite;
        }
        else
        {
            this.soundButton.GetComponentInChildren<Image>().sprite = this.soundEffectOffSprite;
        }
    }
}
