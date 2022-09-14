
using System;
using System.Threading.Tasks;
using Npgsql;
namespace ShatterWorldBattleServer
{
    public class PlayerRepository
    {
        private String TABLE_NAME = "PLAYER";
        
        
        public async Task<Player> Get(int playerId, String username, String password)
        {
            string commandText = $"SELECT * FROM {TABLE_NAME} WHERE PLAYER_ID = @playerId AND USERNAME = @username AND PASSWORD = @password";
            //await
            using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, DatabaseConnection.connection))
            {
                cmd.Parameters.AddWithValue("playerId", playerId);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);
                
                await using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    return ReadPlayer(reader); 
                }
            }
            return null;
        }
        
        private static Player ReadPlayer(NpgsqlDataReader reader)
        {
            string username = reader["username"] as string;
            string password = reader["password"] as string;
            long? idRaw = reader["player_id"] as long?;
            if (!idRaw.HasValue)
            {
                throw new Exception("Player not found");
            }
            int id = (int) idRaw.Value;
            


            Player player = new Player
            (
                id,
                username,
                password
            );
            return player;
        }
    }
}