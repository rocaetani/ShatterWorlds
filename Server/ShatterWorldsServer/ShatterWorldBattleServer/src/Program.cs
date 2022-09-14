namespace ShatterWorldBattleServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DatabaseConnection db = new DatabaseConnection();

            //DatabaseManager datab = new DatabaseManager();
                
            
            NetworkManager.Instance.port = 7777;
            NetworkManager.Instance.maxClientCount = 10;
            NetworkManager.Instance.Start();
            while (true)
            {
                NetworkManager.Instance.FixedUpdate();
            }
        }
    }
}