using UnityEngine;

public class HelpModalManager : MonoBehaviour
{
    [SerializeField]
    private GameObject helpModal;

    public void OpenModal()
    {
        helpModal.SetActive(true);
    }

    public void CloseModal()
    {
        helpModal.SetActive(false);
    }
}
