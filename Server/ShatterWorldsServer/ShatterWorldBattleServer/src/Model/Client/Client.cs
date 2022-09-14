using System.Collections.Generic;
namespace ShatterWorldBattleServer
{
    public class Client
    {
        public ushort Id { get; private set; }

        public Player Player;

        public List<Character> Characters;

        public Client(ushort id)
        {
            Id = id; 
        }
        public Client(ushort id, Player player)
        {
            Id = id;
            Player = player;
        }
    }
}