using System;
using RiptideNetworking;

namespace ShatterWorldBattleServer.Handlers
{
    public class MessageReceiver
    {
        [MessageHandler((ushort)ClientToServerId.loginInfo)]
        private static void ReceiveLoginInfo(ushort fromClientId, Message message)
        {
            Console.WriteLine("ReceiveLoginInfo");
            //TODO - Deserialize message and send username/password to auth
            ServerManager.Instance.StartSingleBattle(fromClientId, message.GetInt(), message.GetString(), message.GetString()); //was extra parameter message.GetString()
        }
        
        [MessageHandler((ushort)ClientToServerId.chosenCharacters)]
        private static void ReceiveChosenCharacters(ushort fromClientId, Message message)
        {
            Console.WriteLine("ReceiveChosenCharacters");
            int playerId = message.GetInt();
            int[] characterIdList = message.GetInts();
            ServerManager.Instance.AddCharactersToBattle(fromClientId, playerId, characterIdList);
        }
        
        [MessageHandler((ushort)ClientToServerId.firstTurn)]
        private static void ReceiveFirstTurn(ushort fromClientId, Message message)
        {
            Console.WriteLine("ReceiveInitBattle");
            ServerManager.Instance.CalculateBattleTurn(fromClientId);
        }
        
        [MessageHandler((ushort)ClientToServerId.endTurn)]
        private static void ReceiveEndTurn(ushort fromClientId, Message message)
        {
            Console.WriteLine("ReceiveEndTurn");
            int agentId = message.GetInt();
            ServerManager.Instance.EndTurn(fromClientId, agentId);
        }
    }
}