namespace ShatterWorldBattleServer
{
    public class Player
    {
        public ushort Id { get; private set; }
        public string Username { get; private set; }

        public Player(ushort id, string username)
        {
            this.Id = id;
            this.Username = string.IsNullOrEmpty(username) ? $"Guest: {id}" : username;
        }
    }
}