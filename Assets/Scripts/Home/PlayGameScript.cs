using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayGameScript : MonoBehaviour
{

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

}
