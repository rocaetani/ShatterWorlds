/*
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Npgsql;
using RiptideNetworking;

namespace ShatterWorldBattleServer
{
    public class MessageConfigRepository
    {

        private String TABLE_NAME = "message_config";
        /*
        public async Task Add(BoardGame game)
        {
            string commandText = $"INSERT INTO {TABLE_NAME} (id, Name, MinPlayers, MaxPlayers, AverageDuration) VALUES (@id, @name, @minPl, @maxPl, @avgDur)";
            await using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("id", game.Id);
                cmd.Parameters.AddWithValue("name", game.Name);
                cmd.Parameters.AddWithValue("minPl", game.MinPlayers);
                cmd.Parameters.AddWithValue("maxPl", game.MaxPlayers);
                cmd.Parameters.AddWithValue("avgDur", game.AverageDuration);

                await cmd.ExecuteNonQueryAsync();
            }
        }
        */
        /*
        public async Task<MessageConfig> Get(int id)
        {
            string commandText = $"SELECT * FROM {TABLE_NAME} WHERE ID = @id";
            //await
            using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, DatabaseConnection.connection))
            {
                cmd.Parameters.AddWithValue("id", id);

                await using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    MessageConfig messageConfig = ReadMessageConfig(reader);
                    return messageConfig;
                }
            }
            return null;
        }
        
        private static MessageConfig ReadMessageConfig(NpgsqlDataReader reader)
        {
            int? idRaw = reader["id"] as int?;
            ushort id = (ushort) idRaw;
            
            string description = reader["description"] as string;

            string sendModeRaw = reader["sendmode"] as string;
            Enum.TryParse(sendModeRaw, out MessageSendMode sendMode);
            
            string contentTypeRaw = reader["contenttype"] as string;
            Type contentType = Type.GetType(contentTypeRaw);

            
            MessageConfig messageConfig = new MessageConfig
            (
                id,
                description,
                contentType,
                sendMode
            );
            return messageConfig;
        }
        
        public async Task<Dictionary<ushort, MessageConfig>> GetAll()
        {
            List<MessageConfig> messageConfigList = new List<MessageConfig>();
            string commandText = $"SELECT * FROM {TABLE_NAME}";
            //await
            using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, DatabaseConnection.connection))
            {
                await using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (reader.HasRows)
                {
                    await reader.NextResultAsync();
                    MessageConfig messageConfig = ReadMessageConfig(reader);
                    messageConfigList.Add(messageConfig);
                }
            }
            return null;
        }
        

        
    }
}
*/