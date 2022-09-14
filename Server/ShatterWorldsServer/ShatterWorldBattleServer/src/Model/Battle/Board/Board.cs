using System;

namespace ShatterWorldBattleServer
{
    public class Board
    {
        public BoardSquare[,] BoardStructure;

        public int BoardSize;

        public Board(int boardSize)
        {
            BoardSize = boardSize;
            BoardStructure = new BoardSquare[boardSize,boardSize];
            InitiateBoard();
            //Console.WriteLine($" {boardSize}");
        }

        private void InitiateBoard()
        {
            for (int i = 0; i < BoardSize-1; i++)
            {
                for (int j = 0; j < BoardSize-1; j++)
                {
                    BoardStructure[i,j] = new BoardSquare();
                }
            }
        }
    }
}