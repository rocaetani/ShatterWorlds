using System;
using System.Collections.Generic;
using ShatterWorldBattleServer.Helpers;

namespace ShatterWorldBattleServer
{
    public class Battle
    {
        public Client[] clientList;

        public int BattleSeed;

        public Random BattleRandom;
        
        public Board Board;

        public TurnManager TurnManager;
        
        
        
        public Battle(Client client)
        {
            clientList = new Client[1];
            //Client client = new Client(clientId);

            clientList[0] = client;
            
            BattleSeed = DateTime.Now.Millisecond;
            
            BattleRandom = new Random(BattleSeed);
            
            Board = new Board(BattleRandom.Next(Macros.MIN_BOARD_SIZE, Macros.MAX_BOARD_SIZE));
        }

        public bool IsSingleBattle()
        {
            return clientList.Length > 1;
        }

        public Client FindClient(ushort clientId)
        {
            foreach (Client client in clientList)
            {
                if (client.Id == clientId) return client;
            }
            return null;
        }

        public void AddCharactersToClient(ushort clientId, List<Character> characters)
        {
            Client client = FindClient(clientId);
            if (client == null)
            {
                Console.WriteLine($"Client {clientId}: Not found inside Battle");
                //TODO - Throw Error
            }
            else
            {
                client.Characters = characters; 
            }
        }



    }
}