using System;
using RiptideNetworking;

namespace ShatterWorldBattleServer
{
    public class SeedMessage : MessagePreparer<int>
    {
        private ushort ID = 1;

        protected override Message PrepareMessage(int content)
        {
            Message message = Message.Create(MessageSendMode.reliable, ID);
            message.Add(content);
            return message;
        }
    }
}