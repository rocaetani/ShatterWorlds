using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.AccessControl;
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
            _gamesManager = new GamesManager();
            _databaseManager = new DatabaseManager();
        }

        public static ServerManager Instance { get; } = new ServerManager();

        private GamesManager _gamesManager;

        private DatabaseManager _databaseManager;

        public void StartSingleBattle(ushort clientId, int playerId, string username, string password)
        {
            //Find Player on battle
            Player player = _databaseManager.FindPlayer(playerId, username, password);
            
            //Create Client 
            Client client = new Client(clientId);
            
            //Create Battle
            _gamesManager.StartSingleBattle(client);
            
            //Send Seed to the client
            SendBattleSeedToClient(_gamesManager.GetBattleSeed(clientId), clientId);
        }

        public void AddCharactersToBattle(ushort clientId, int playerId, int[] charactersId)
        {
            List<Character> characters = _databaseManager.FindCharacters(playerId, charactersId);
            //Add to Battle
            _gamesManager.AddCharactersToBattle(clientId, characters);
            //Return Message OK to client;    
            MessageSender.SendCharactersValid(clientId, true);
        }
        
        private void SendBattleSeedToClient(int battleSeed, ushort clientId)
        {
            MessageSender.SendSeed(clientId, battleSeed);
        }

        public void OnClientDisconnect(object sender, ClientDisconnectedEventArgs e)
        {
            if (_gamesManager.IsClientFromSingleBattle(e.Id))
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
            _gamesManager.RemoveBattle(clientId);
        }

        
        private void DisconnectClientFromMultiplayerBattle(ushort clientId)
        {
            //TODO - End the Multiple Battle in a way
            _gamesManager.RemoveBattle(clientId);
        }
        
        public void CalculateBattleTurn(ushort clientId)
        {
            int nextToPlayId = _gamesManager.CalculateBattleTurn(clientId);
            MessageSender.SendNextToPlay(clientId, nextToPlayId, VerifyAgentType(nextToPlayId));
        }

        private int VerifyAgentType(int nextToPlayId)
        {
            if (nextToPlayId > 0)
            {
                return 1; //PlayerAgent
            }
            return 2; //AIAgent
            
            //TODO - EnemyPlayerAgent
        }
        
        public void EndTurn(ushort clientId, int agentId)
        {
            _gamesManager.EndTurn(clientId, agentId);
            CalculateBattleTurn(clientId);
        }

    }
}
