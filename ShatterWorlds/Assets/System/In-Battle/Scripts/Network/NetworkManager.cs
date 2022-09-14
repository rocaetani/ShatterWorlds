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

    private static BattleManager _battleManager;

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

    public void SignBattleManager(BattleManager battleManager)
    {
        _battleManager = battleManager;
    }

    private void FixedUpdate()
    {
        Client.Tick();
    }

    private void OnApplicationQuit()
    {
        Client.Disconnect();
    }

    public void Connect()
    {
        Client.Connect($"{ip}:{port}");
    }

    private void DidConnect(object sender, EventArgs e)
    {
        _battleManager.SendLoginInfoToServer();
    }
    private void FailToConnect(object sender, EventArgs e)
    {
        ErrorLogger.instance.LogError("Fail to connect on server", this);
        ReturnToMainMenu();
    }

    private void DidDisconnect(object sender, EventArgs e)
    {
        GameLogger.instance.Log("Disconnected...", this);
        ReturnToMainMenu();
    }

    private void ReturnToMainMenu()
    {
        SceneTransactional.instance.InToOutTransaction.comebackMenu = MenuController.MenuItemCategory.Main;
        SceneTransactional.instance.InToOutTransaction.Player = _battleManager.Player;
        SceneTransactional.instance.ChangeToMainMenu();
    }

}
