public class BattleRandom
{
    private int _battleSeed;

    private System.Random _randomizer;

    public BattleRandom(int seed)
    {
        _battleSeed = seed;
        _randomizer = new System.Random(_battleSeed);
    }

    public int GenerateRandInt(int min, int max)
    {
        return _randomizer.Next(min, max);
    }
    
}
