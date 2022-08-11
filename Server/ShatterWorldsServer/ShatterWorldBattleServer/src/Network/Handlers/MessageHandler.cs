using System;
using RiptideNetworking;

namespace ShatterWorldBattleServer.Handlers
{
    public class MessageHandler
    {
        [MessageHandler((ushort)ClientToServerId.connect)]
        private static void Name(ushort fromClientId, Message message)
        {
            BattlesManager.Instance.StartSingleBattle(fromClientId); //was extra parameter message.GetString()
            Console.WriteLine($"Client {fromClientId}: {message.GetString()} Spawned ");
        }
    }
}