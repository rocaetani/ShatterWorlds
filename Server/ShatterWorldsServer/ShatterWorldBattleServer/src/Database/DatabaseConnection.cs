using Npgsql;

namespace ShatterWorldBattleServer
{
    public class DatabaseConnection
    {
        public static NpgsqlConnection connection;
        
        private const string CONNECTION_STRING = "Host=localhost:8134;" +
                                                 "Username=postgres;" +
                                                 "Password=SW4815;" +
                                                 "Database=postgres";

        public DatabaseConnection()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }
    }
}