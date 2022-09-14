using System;
using System.Collections.Generic;
using System.Diagnostics;
using RiptideNetworking;
using ShatterWorldBattleServer.Handlers;

namespace ShatterWorldBattleServer
{
    public class ServerManager
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as before field init
        static ServerManager() {}

        private ServerManager()
        {
            _battlesManager = new BattlesManager();
            _databaseManager = new DatabaseManager();
        }

        public static ServerManager Instance { get; } = new ServerManager();

        private BattlesManager _battlesManager;

        private DatabaseManager _databaseManager;

        public void StartSingleBattle(ushort clientId, int playerId, string username, string password)
        {
            //Find Player on battle
            Player player = _databaseManager.FindPlayer(playerId, username, password);
            
            //Create Client 
            Client client = new Client(clientId);
            
            //Create Battle
            _battlesManager.StartSingleBattle(client);
            
            //Send Seed to the client
            SendBattleSeedToClient(_battlesManager.GetBattleSeed(clientId), clientId);
        }

        public void AddCharactersToBattle(ushort clientId, int playerId, int[] charactersId)
        {
            List<Character> characters = _databaseManager.FindCharacters(playerId, charactersId);
            //Add to Battle
            _battlesManager.AddCharactersToBattle(clientId, characters);
            //Return Message OK to client;    
            MessageSender.CharactersValidMessage.Send(clientId, true);
        }
        
        private void SendBattleSeedToClient(int battleSeed, ushort clientId)
        {
            MessageSender.SeedMessage.Send(clientId, battleSeed);
        }

        public void OnClientDisconnect(object sender, ClientDisconnectedEventArgs e)
        {
            if (_battlesManager.IsClientFromSingleBattle(e.Id))
            {
                DisconnectClientFromSingleBattle(e.Id);
            }
            else
            {
                DisconnectClientFromMultiplayerBattle(e.Id);
            }
            
        }

        private void DisconnectClientFromSingleBattle(ushort clientId)
        {
            _battlesManager.RemoveBattle(clientId);
        }

        
        private void DisconnectClientFromMultiplayerBattle(ushort clientId)
        {
            //TODO - End the Multiple Battle in a way
            _battlesManager.RemoveBattle(clientId);
        }

    }
}
