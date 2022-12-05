using System.Collections.Generic;
public class AgentManager
{
    public Dictionary<int, Agent> Agents;

    public AgentManager()
    {
        Agents = new Dictionary<int, Agent>();
    }

    public void AddAgents(List<Agent> agents)
    {
        foreach (Agent agent in agents)
        {
            Agents.Add(agent.GetAgentId(), agent);
        }
    }

    public void AddAgent(Agent agent)
    {
        Agents.Add(agent.GetAgentId(), agent);
    }
    
    public void AddCharacters(List<Character> agents)
    {
        foreach (Character agent in agents)
        {
            Agents.Add(agent.GetAgentId(), agent);
        }
    }
    
    


}

