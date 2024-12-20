using UnityEngine;

public class HelpModalManager : MonoBehaviour
{
    [SerializeField]
    private GameObject helpModal;

    public void OpenModal()
    {
        this.helpModal.SetActive(true);
    }

    public void CloseModal()
    {
        this.helpModal.SetActive(false);
    }
}
