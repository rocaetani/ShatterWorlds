public abstract class Agent
{
    public float CurrentPoints;
    public int BaseTurnSpeed;
    
    
    public Agent(int baseTurnSpeed)
    {
        CurrentPoints = 0;
        BaseTurnSpeed = baseTurnSpeed;
    }

    public void CalculatePoints(float closerNumberOfTurns)
    {
        CurrentPoints += BaseTurnSpeed * closerNumberOfTurns;
    }

    public float TurnsMissingToPlay(int threshold)
    {
        float missingPoints = threshold - CurrentPoints;
        return missingPoints / BaseTurnSpeed;
    }

    public void ErasePoints()
    {
        CurrentPoints = 0;
    }

    protected abstract int BaseSpeed();
    public abstract int GetAgentId();
}

