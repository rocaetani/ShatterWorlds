using System;
using RiptideNetworking;

namespace ShatterWorldBattleServer
{
    public class MessageConfig
    {
        public ushort Id;
        public String Description;
        public Type ContentType;
        public MessageSendMode SendMode;

        public MessageConfig(ushort messageId, string messageDescription, Type contentType, MessageSendMode messageSendMode)
        {
            Id = messageId;
            Description = messageDescription;
            ContentType = contentType;
            SendMode = messageSendMode;
        }
    }
}