using System.Collections.Generic;
using System.Linq;
namespace ShatterWorldBattleServer
{
    public class DatabaseManager
    {
        private PlayerRepository _playerRepository;
        private CharacterRepository _characterRepository;

        public DatabaseManager()
        {
            _playerRepository = new PlayerRepository();
            _characterRepository = new CharacterRepository();
        }
        
        public Player FindPlayer(int playerId, string username, string password)
        {
            return _playerRepository.Get(playerId, username, password).Result;
        }

        public List<Character> FindCharacters(int playerId, int[] charactersId)
        {
            return _characterRepository.Get(playerId, charactersId).Result;
        }
    
    }
}