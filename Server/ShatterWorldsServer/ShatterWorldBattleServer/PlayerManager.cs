using System;
using System.Collections.Generic;
using RiptideNetworking;
namespace ShatterWorldBattleServer
{
    public class PlayerManager
    {
        private static readonly PlayerManager instance = new PlayerManager();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static PlayerManager()
        {
        }

        private PlayerManager()
        {
            
        }

        public static PlayerManager Instance
        {
            get
            {
                return instance;
            }
        }
        
        public static Dictionary<ushort, Player> playerList = new Dictionary<ushort, Player>();
        
        [MessageHandler((ushort)ClientToServerId.name)]
        private static void Name(ushort fromClientId, Message message)
        {
            SpawnPlayer(fromClientId, message.GetString());
            Console.WriteLine($"Player {fromClientId}: {message.GetString()} Spawned ");
        }

        private static void SpawnPlayer(ushort id, string username)
        {
            Player player = new Player(id, username);
            playerList.Add(id, player);
        }

        private void DestroyPlayer(ushort id)
        {
            Player player = playerList[id];
            playerList.Remove(id);
            Console.WriteLine($"Player {player.Id}: {player.Username} Disconnected and Destroyed ");
        }
        
        public void OnPlayerDisconnect(object sender, ClientDisconnectedEventArgs e)
        {
            DestroyPlayer(e.Id);
        }
        
    }
    
    


}