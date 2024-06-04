using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class MainMenu : MonoBehaviour
{
    public bool remote = false;
    public UnityTransport transport;
    public string ip;
    public ushort port;

    private void Start()
    {
        DontDestroyOnLoad(NetworkManager.Singleton.gameObject);
        UIManager.Instance.HideInfo();
        Debug.Log("MainMenu initialized");
    }

    // Start is called before the first frame update
    public void HostGame()
    {
        if (remote)
        {
            Debug.Log($"Setting up server to listen for all addresses on port {port}");
            transport.ConnectionData.Address = "0.0.0.0";
            transport.ConnectionData.Port = port;
        }

        Debug.Log("Starting Host...");
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host started");

        NetworkManager.Singleton.SceneManager.LoadScene("Main", LoadSceneMode.Single);
        UIManager.Instance.DisplayInfo();
        Debug.Log("Scene Main loaded");
    }

    public void JoinGame()
    {
        if (remote)
        {
            Debug.Log($"Setting up remote connection to {ip}:{port}");
            transport.ConnectionData.Address = ip;
            transport.ConnectionData.Port = port;
        }

        Debug.Log("Starting Client...");
        NetworkManager.Singleton.StartClient();
        Debug.Log("Client started");
        UIManager.Instance.DisplayInfo();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    private IEnumerator WaitForClients()
    {
        Debug.Log("Waiting for clients...");
        while (NetworkManager.Singleton.ConnectedClients.Count <= 1)
        {
            yield return null;
        }

        Debug.Log("Clients connected, loading Main scene");
        NetworkManager.Singleton.SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
