using System;
using UnityEngine;
public abstract class Agent
{
    private int _turnPoints;

    private int _turnSpeed;

    private AgentView _agentView;

    public AgentType Type;



    public Agent(GameObject parent, int turnSpeed, AgentType type)
    {
        _agentView = AgentFactory.SpawnTurnView(parent);
        //_agentView.SetupPosition();
        _turnPoints = 0;
        _turnSpeed = turnSpeed;
        Type = type;
    }

    public void CalculateTurnPoints()
    {
        _turnPoints += _turnSpeed;
        _agentView.UpdateTurnBar(_turnPoints);
    }

    public void UpdateTurnPoints(int newValue)
    {
        _turnSpeed = newValue;
    }

    public void CleanPoints()
    {
        _turnPoints = 0;
    }

    public abstract int GetAgentId();

}
