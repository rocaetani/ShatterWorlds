using System;
using RiptideNetworking;
using ShatterWorldBattleServer.Handlers;

namespace ShatterWorldBattleServer
{
    public class SeedMessage : MessagePreparer<int>
    {
        private ServerToClientId ID = ServerToClientId.seed;

        protected override Message PrepareMessage(int content)
        {
            Message message = Message.Create(MessageSendMode.reliable, ID);
            message.Add(content);
            return message;
        }
    }
}