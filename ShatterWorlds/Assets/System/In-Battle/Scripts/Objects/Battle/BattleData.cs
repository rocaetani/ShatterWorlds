using outBattle;

public class BattleData
{
    public BattleRandom BattleRandom;

    public Player Player;

    public BattleData(Player player, int seed)
    {
        Player = player;
        BattleRandom = new BattleRandom(seed);
    }

    public int GetRandomNumber(int min, int max)
    {
        return BattleRandom.GenerateRandInt(min, max);
    }

    public int GetRandomBoardSize()
    {
        return BattleRandom.GenerateRandInt(Macros.MIN_BOARD_SIZE, Macros.MAX_BOARD_SIZE);
    }
}
