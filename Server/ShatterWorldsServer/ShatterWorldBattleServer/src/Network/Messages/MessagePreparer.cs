using RiptideNetworking;

namespace ShatterWorldBattleServer
{
    public abstract class MessagePreparer<T>
    {
        protected abstract Message PrepareMessage(T content);

        public void Send(T content, ushort clientId)
        {
            NetworkManager.Instance.Server.Send(PrepareMessage(content), clientId);
        }
    }
}