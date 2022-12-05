using System.Collections.Generic;
using UnityEngine;
namespace InBattle
{
    public class BoardManager
    {
        private Dictionary<Vector2Int, Square> BoardStructure;

        public BoardManager(int size, GameObject boardBucket)
        {
            InitBoardStructure(size, boardBucket);
        }

        private void InitBoardStructure(int boardSize, GameObject boardBucket)
        {
            BoardStructure = new Dictionary<Vector2Int, Square>();
            for (int i = 0; i < boardSize - 1; i++)
            {
                for (int j = 0; j < boardSize - 1; j++)
                {
                    Vector2Int squarePosition = new Vector2Int(i, j);
                    Square square = InstantiateSquare(i, j, boardBucket);
                    BoardStructure.Add(squarePosition, square);
                }
            }
        }

        private Square InstantiateSquare(float x, float z, GameObject boardBucket)
        {
            return SquareFactory.SpawnSquare(x, z, boardBucket);
        }

        public void PutObjectInSquare(Vector2Int squarePosition, Attachable attachable)
        {
            if (!SquareExists(squarePosition))
            {
                ErrorLogger.instance.LogError("Square not found in method 'PutObjectInSquare'", this);
                return;
            }
            BoardStructure[squarePosition].AttachObject(attachable);
        }

        public bool SquareExists(Vector2Int squarePosition)
        {
            return BoardStructure.ContainsKey(squarePosition);
        }
    }
}
