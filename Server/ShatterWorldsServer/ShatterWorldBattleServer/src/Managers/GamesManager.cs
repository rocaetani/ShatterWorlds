using System;
using System.Collections.Generic;
using RiptideNetworking;
using ShatterWorldBattleServer.Handlers;

namespace ShatterWorldBattleServer
{
    public class GamesManager
    {
        private readonly Dictionary<ushort, BattleManager> BattlesList = new Dictionary<ushort, BattleManager>();

        public void StartSingleBattle(Client client)
        {
            BattleManager battleManager = new BattleManager(client);
            BattlesList.Add(client.Id, battleManager);
        }

        public int GetBattleSeed(ushort clientId)
        {
            if (!BattlesList.ContainsKey(clientId))
            {
                //throw error
            }
            else
            {
                Battle b = BattlesList[clientId].Battle;
                int seed = b.BattleSeed;
                return BattlesList[clientId].Battle.BattleSeed;
            }
            return -1;
        }
        

        public void RemoveBattle(ushort clientId)
        {
            //TODO - See if there is a way for garbage collector to instant destroy all Battle three
            BattlesList.Remove(clientId);
            //Console.WriteLine($"Client {client.Id}: Disconnected and Destroyed ");
        }

        public bool IsClientFromSingleBattle(ushort clientId)
        {
            return BattlesList[clientId].Battle.IsSingleBattle();
        }

        public void AddCharactersToBattle(ushort clientId, List<Character> characters)
        {
            BattlesList[clientId].AddCharactersToBattle(clientId, characters);
        }

        public int CalculateBattleTurn(ushort clientId)
        {
            return BattlesList[clientId].TurnManager.CalculateNextTurn();
        }

        public void EndTurn(ushort clientId, int agentId)
        {
            BattlesList[clientId].TurnManager.EndTurn(agentId);
        }
    }
}