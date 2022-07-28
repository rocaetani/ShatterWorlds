namespace ShatterWorldBattleServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
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