using System;
using RiptideNetworking;
using RiptideNetworking.Utils;

namespace ShatterWorldBattleServer
{
    
    public enum ClientToServerId : ushort
    {
        name = 1,
    }

    public class NetworkManager
    {
        private static readonly NetworkManager instance = new NetworkManager();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static NetworkManager()
        {
        }

        private NetworkManager()
        {
        }

        public static NetworkManager Instance
        {
            get
            {
                return instance;
            }
        }
    
        
        public Server Server { get; private set; }

        public ushort port;
        public ushort maxClientCount;
        

        public void Start()
        {
            //Application.targetFrameRate = 60;

            RiptideLogger.Initialize(Console.WriteLine, Console.WriteLine, Console.WriteLine, Console.WriteLine, false);

            Server = new Server();
            Server.Start(port, maxClientCount);
            Server.ClientDisconnected += PlayerManager.Instance.OnPlayerDisconnect;
        }

        public void FixedUpdate()
        {
            Server.Tick();
        }

        /*
        
        private void OnApplicationQuit()
        {
            Server.Stop();
        }

        private void PlayerLeft(object sender, ClientDisconnectedEventArgs e)
        {
            Destroy(Player.list[e.Id].gameObject);
        }
        */
    }
    
    
}