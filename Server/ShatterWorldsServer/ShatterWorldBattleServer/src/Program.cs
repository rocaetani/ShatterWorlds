namespace ShatterWorldBattleServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            DatabaseConnection db = new DatabaseConnection();
            //MessageConfigRepository mcrep = new MessageConfigRepository();
            //MessageConfig mc = mcrep.Get(1).Result;
            
            
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