using RiptideNetworking;

namespace ShatterWorldBattleServer
{
    public abstract class MessagePreparer<T>
    {
        protected abstract Message PrepareMessage(T content);

        public void Send(ushort clientId, T content)
        {
            NetworkManager.Instance.Server.Send(PrepareMessage(content), clientId);
        }
    }
}