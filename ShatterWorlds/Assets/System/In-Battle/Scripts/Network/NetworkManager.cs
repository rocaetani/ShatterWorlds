using System;
using outBattle;
using RiptideNetworking.Utils;
using RiptideNetworking;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    private static NetworkManager _singleton;
    public static NetworkManager Singleton
    {
        get
        {
            return _singleton;
        }
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"{nameof(NetworkManager)} instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }

    public Action OnDisconnect;
    public Action OnFailToConnect;
    public Action OnConnect;

    public Client Client { get; private set; }

    [SerializeField] private string ip;
    [SerializeField] private ushort port;

    private void Awake()
    {
        Singleton = this;
        RiptideLogger.Initialize(Debug.Log, Debug.Log, Debug.LogWarning, Debug.LogError, false);

        Client = new Client();
        Client.Connected += DidConnect;
        Client.Disconnected += DidDisconnect;
        Client.ConnectionFailed += FailToConnect;
    }

    private void FixedUpdate()
    {
        Client.Tick();
    }

    private void OnApplicationQuit()
    {
        Client.Disconnect();
    }

    public void Connect(Action onConnect, Action onDisconnect, Action onFailToConnect)
    {
        OnConnect = onConnect;
        OnDisconnect = onDisconnect;
        OnFailToConnect = onFailToConnect;
        Client.Connect($"{ip}:{port}");
    }

    private void DidConnect(object sender, EventArgs e)
    {
        OnConnect?.Invoke();
    }
    private void FailToConnect(object sender, EventArgs e)
    {
        ErrorLogger.instance.LogError("Fail to connect on server", this);
        OnFailToConnect?.Invoke();
    }

    private void DidDisconnect(object sender, EventArgs e)
    {
        GameLogger.instance.Log("Disconnected...", this);
        OnDisconnect?.Invoke();
    }

}
