using System;
using RiptideNetworking;
using ShatterWorldBattleServer.Handlers;

namespace ShatterWorldBattleServer
{
    public class CharactersValidMessage : MessagePreparer<bool>
    {
        private ServerToClientId ID = ServerToClientId.charactersValid;

        protected override Message PrepareMessage(bool content)
        {
            Message message = Message.Create(MessageSendMode.reliable, ID);
            message.Add(content);
            return message;
        }
    }
}