using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
namespace ShatterWorldBattleServer
{
    public class CharacterRepository
    {
        private String TABLE_NAME = "CHARACTER";


        public async Task<List<Character>> Get(int playerId, int[] characterIds)
        {
            List<Character> characters = new List<Character>();

            string commandText =
                "SELECT C.*, " +
                "       BC.NAME AS BASIC_CLASS, " +
                "       A.* " +
                "  FROM CHARACTER C " +
                "  JOIN BASIC_CLASS BC " +
                "    ON C.BASIC_CLASS_ID = BC.BASIC_CLASS_ID" +
                "  JOIN ATTRIBUTES A " +
                "    ON A.CHARACTER_ID = C.CHARACTER_ID" +
                " WHERE C.PLAYER_OWNER_ID = @playerId " +
                "   AND C.CHARACTER_ID = ANY(:characterIds)";

            using (NpgsqlCommand cmd = new NpgsqlCommand(commandText, DatabaseConnection.connection))
            {
                cmd.Parameters.AddWithValue("playerId", playerId);


                //cmd.Parameters.AddWithValue("characterIds", characterIds);
                
                NpgsqlParameter p = new NpgsqlParameter("characterIds", NpgsqlDbType.Array | NpgsqlDbType.Integer);
                p.Value = characterIds;
                cmd.Parameters.Add(p);
                

                await using NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

                int i = 0;

                while (await reader.ReadAsync())
                {
                    characters.Add(ReadCharacter(reader));
                }
            }
            return characters;
        }

        private static Character ReadCharacter(NpgsqlDataReader reader)
        {
            
            int characterId;
            
            long? idRaw = reader["character_id"] as long?;
            if (!idRaw.HasValue)
            {
                throw new Exception("Basic Class not found");
            }
            int id = (int)idRaw.Value;
            
            String name = reader["name"] as string;

            String race = reader["race"] as string;

            BasicClass basicClass = ReadBasicClass(reader);

            int level = reader["level"] as int? ?? 0;

            int experiencePoints = reader["experience_points"] as int? ?? 0;

            Attributes attributes = ReadAttributes(reader);

            return new Character(id, name, race, basicClass, level, experiencePoints, attributes);
        }
        
        private static BasicClass ReadBasicClass(NpgsqlDataReader reader)
        {
            string name = reader["basic_class"] as string; 
            long? idRaw = reader["basic_class_id"] as long?;
            if (!idRaw.HasValue)
            {
                throw new Exception("Basic Class not found");
            }
            int id = (int)idRaw.Value;
            return new BasicClass(id, name);
        }

        private static Attributes ReadAttributes(NpgsqlDataReader reader)
        { 
    
            long? idRaw = reader["attributes_id"] as long?;
            if (!idRaw.HasValue)
            {
                throw new Exception("Basic Class not found");
            }
            int id = (int)idRaw.Value;
            int strength = ( reader["strength"] as int?) ?? 0;
            int technique = (reader["technique"] as int?) ?? 0;
            int dexterity = (reader["dexterity"] as int?) ?? 0;
            int velocity = (reader["velocity"] as int?) ?? 0;
            int intelligence = (reader["intelligence"] as int?) ?? 0;
            int knowledge = (reader["knowledge"] as int?) ?? 0;
            int spirituality = (reader["spirituality"] as int?) ?? 0;
            int will = (reader["will"] as int?) ?? 0;

            return new Attributes(id, strength, technique, dexterity, velocity, intelligence, knowledge, spirituality, will);
        }
        
 
    }
}
