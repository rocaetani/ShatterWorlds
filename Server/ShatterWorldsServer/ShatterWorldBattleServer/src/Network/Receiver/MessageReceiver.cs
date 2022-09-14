using System;
using RiptideNetworking;

namespace ShatterWorldBattleServer.Handlers
{
    public class MessageReceiver
    {
        [MessageHandler((ushort)ClientToServerId.connect)]
        private static void Connect(ushort fromClientId, Message message)
        {
            Console.WriteLine($"Connect received from client: {fromClientId}");
            //TODO - Deserialize message and send username/password to auth
            ServerManager.Instance.StartSingleBattle(fromClientId, message.GetInt(), message.GetString(), message.GetString()); //was extra parameter message.GetString()
            
        }
        
        [MessageHandler((ushort)ClientToServerId.chosenChar acters)]
        private static void ChosenCharacters(ushort fromClientId, Message message)
        {
            Console.WriteLine($"ChosenCharacters received from client: {fromClientId}");
            int playerId = message.GetInt();
            int[] characterIdList = message.GetInts();
            ServerManager.Instance.AddCharactersToBattle(fromClientId, playerId, characterIdList);
        }
    }
}