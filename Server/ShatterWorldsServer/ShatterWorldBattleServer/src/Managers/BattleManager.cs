using System.Collections.Generic;
using System.Linq;
namespace ShatterWorldBattleServer
{
    public class BattleManager
    {
        public Battle Battle;
        public TurnManager TurnManager;
        public AgentManager AgentManager;

        public BattleManager(Client client)
        {
            Battle = new Battle(client);    
            TurnManager = new TurnManager();
            AgentManager = new AgentManager();
        }
        
        public void AddCharactersToBattle(ushort clientId, List<Character> characters)
        {
            AgentManager.AddCharacters(characters);
            Battle.AddCharactersToClient(clientId, characters);
            TurnManager.AddAgents(AgentManager.Agents.Values.ToList());
        }

    }

}