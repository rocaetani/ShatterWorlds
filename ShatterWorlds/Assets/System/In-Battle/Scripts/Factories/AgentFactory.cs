using UnityEngine;
public class AgentFactory
{
    private static readonly GameObject agentPrefab = Resources.Load<GameObject>("InBattle/Prefabs/AgentView");
    public static AgentView SpawnAgentView(GameObject parent)
    {
        // TODO Do a Agent View with the bar
        GameObject agentSpawned = Object.Instantiate(agentPrefab, parent.transform.position, Quaternion.identity, parent.transform);
        AgentView agentView = agentSpawned.GetComponent<AgentView>();
        return agentView;
    }

}
