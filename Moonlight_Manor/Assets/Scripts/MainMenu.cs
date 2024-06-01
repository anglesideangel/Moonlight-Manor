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
        //StartCoroutine(WaitForClients());
        NetworkManager.Singleton.SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void JoinGame()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator WaitForClients()
    {
        while (NetworkManager.Singleton.ConnectedClients.Count <= 1)
        {
            yield return null;
        }

        NetworkManager.Singleton.SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
