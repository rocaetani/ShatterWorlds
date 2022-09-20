using outBattle;

public class BattleData
{
    public Board Board;

    public BattleRandom BattleRandom;

    public Player Player;

    public BattleData(Player player, int seed)
    {
        Player = player;
        BattleRandom = new BattleRandom(seed);
        int boardSize = BattleRandom.GenerateRandInt(Macros.MIN_BOARD_SIZE, Macros.MAX_BOARD_SIZE);
        Board = BoardFactory.SpawnBoard(boardSize);
    }
}
