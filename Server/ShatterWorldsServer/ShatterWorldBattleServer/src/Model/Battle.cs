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

        
        public Battle(ushort clientId)
        {
            clientList = new Client[1];
            Client client = new Client(clientId);
            
            BattleSeed = DateTime.Now.Millisecond;
            
            BattleRandom = new Random(BattleSeed);
            
            Board = new Board(BattleRandom.Next(Macros.MIN_BOARD_SIZE, Macros.MAX_BOARD_SIZE));
        }

        public bool IsSingleBattle()
        {
            return clientList.Length > 1;
        }



    }
}