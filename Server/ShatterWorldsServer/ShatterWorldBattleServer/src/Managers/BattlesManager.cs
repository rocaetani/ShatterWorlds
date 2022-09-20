using System;
using System.Collections.Generic;
using RiptideNetworking;
using ShatterWorldBattleServer.Handlers;

namespace ShatterWorldBattleServer
{
    public class BattlesManager
    {

        private readonly Dictionary<ushort, Battle> BattlesList = new Dictionary<ushort, Battle>();

        public void StartSingleBattle(Client client)
        {
            Battle battle = new Battle(client);
            BattlesList.Add(client.Id, battle);
            //SendBattleSeedToClient(battle.BattleSeed, clientId);
        }

        public int GetBattleSeed(ushort clientId)
        {
            if (!BattlesList.ContainsKey(clientId))
            {
                //throw error
            }
            else
            {
                return BattlesList[clientId].BattleSeed;
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
            return BattlesList[clientId].IsSingleBattle();
        }

        public void AddCharactersToBattle(ushort clientId, List<Character> characters)
        {
            BattlesList[clientId].AddCharactersToClient(clientId, characters);
        }
        
    }
}