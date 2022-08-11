using System;
using System.Collections.Generic;
using RiptideNetworking;
using ShatterWorldBattleServer.Handlers;

namespace ShatterWorldBattleServer
{
    public class BattlesManager
    {
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static BattlesManager() {}

        private BattlesManager() {}

        public static BattlesManager Instance { get; } = new BattlesManager();

        private readonly Dictionary<ushort, Battle> BattlesList = new Dictionary<ushort, Battle>();

        public void StartSingleBattle(ushort clientId)
        {
            Battle battle = new Battle(clientId);
            BattlesList.Add(clientId, battle);
            SendBattleSeedToClient(battle.BattleSeed, clientId);
        }

        private void SendBattleSeedToClient(int battleSeed, ushort clientId)
        {
            MessageManager.SeedMessage.Send(battleSeed, clientId);
        }

        private void DisconnectClientFromMultiplayerBattle(ushort id)
        {
            //TODO
        }

        private void DisconnectClientFromSingleBattle(ushort id)
        {
            //TODO - See if there is a way for garbage collector to instant destroy all Battle three
            BattlesList.Remove(id);
            //Console.WriteLine($"Client {client.Id}: Disconnected and Destroyed ");
        }

        public bool IsClientFromSingleBattle(ushort id)
        {
            return BattlesList[id].IsSingleBattle();
        }

        public void OnClientDisconnect(object sender, ClientDisconnectedEventArgs e)
        {
            if (IsClientFromSingleBattle(e.Id))
            {
                DisconnectClientFromSingleBattle(e.Id);
            }
            else
            {
                DisconnectClientFromMultiplayerBattle(e.Id);
            }


        }
    }
}