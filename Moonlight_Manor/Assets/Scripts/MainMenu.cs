using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad(NetworkManager.Singleton.gameObject);
    }

    // Start is called before the first frame update
    public void HostGame()
    {
        NetworkManager.Singleton.StartHost();
        SceneManager.LoadScene("Main");
    }

    public void JoinGame()
    {
        NetworkManager.Singleton.StartClient();
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
