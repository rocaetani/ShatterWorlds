using UnityEngine;
public class AgentFactory
{
    public static AgentView SpawnTurnView(GameObject parent)
    {
        // TODO Do a Agent View with the bar
        GameObject turnPrefab = Resources.Load<GameObject>("InBattle/Prefabs/AgentView");
        GameObject turnSpawned = Object.Instantiate(turnPrefab, parent.transform.position, Quaternion.identity, parent.transform);
        AgentView agentView = turnSpawned.GetComponent<AgentView>();
        return agentView;
    }

}
