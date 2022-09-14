using System;
using System.Collections.Generic;
using RiptideNetworking;
using RiptideNetworking.Utils;

namespace ShatterWorldBattleServer
{
    
    public class NetworkManager
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static NetworkManager() {}
        private NetworkManager() {}

        public static NetworkManager Instance { get; } = new NetworkManager();
        
        public Server Server { get; private set; }

        public ushort port;
        public ushort maxClientCount;
        

        public void Start()
        {
            //Application.targetFrameRate = 60;

            RiptideLogger.Initialize(Console.WriteLine, Console.WriteLine, Console.WriteLine, Console.WriteLine, false);

            Server = new Server();
            Server.Start(port, maxClientCount);
            Server.ClientDisconnected += ServerManager.Instance.OnClientDisconnect;
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