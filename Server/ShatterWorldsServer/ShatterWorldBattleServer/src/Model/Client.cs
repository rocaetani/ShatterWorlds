namespace ShatterWorldBattleServer
{
    public class Client
    {
        public ushort Id { get; private set; }
        
        public Client(ushort id)
        {
            Id = id;
        }
    }
}