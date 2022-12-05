
using System;
using System.Collections.Generic;
using System.Diagnostics;
using RiptideNetworking;
using ShatterWorldBattleServer.Handlers;

namespace ShatterWorldBattleServer
{
    public static class MessageSender
    {
        //public static readonly SeedMessage SeedMessage = new SeedMessage();
        //public static readonly CharactersValidMessage CharactersValidMessage = new CharactersValidMessage();
        
        public static void SendSeed(ushort clientId, int battleSeed)
        {
            Message message = Message.Create(MessageSendMode.reliable, (ushort)ServerToClientId.seed);

            message.AddInt(battleSeed);

            NetworkManager.Instance.Server.Send(message, clientId);
            Console.WriteLine("SendSeed");
        }
        
        public static void SendCharactersValid(ushort clientId, bool isValid)
        {
            Message message = Message.Create(MessageSendMode.reliable, (ushort) ServerToClientId.charactersValid);

            message.AddBool(isValid);
            
            NetworkManager.Instance.Server.Send(message, clientId);
            Console.WriteLine("SendCharactersValid");
        }
        
        public static void SendNextToPlay(ushort clientId, int nextAgentToPlayId, int nextToPlayType)
        {
            Message message = Message.Create(MessageSendMode.reliable, (ushort) ServerToClientId.nextToPlay);

            message.AddInt(nextAgentToPlayId);
            message.AddInt(nextToPlayType);

            NetworkManager.Instance.Server.Send(message, clientId);
            //TODO Continuar daqui- ajustar recebimento
            Console.WriteLine("SendNextToPlay");
        }
            
            
    }
}