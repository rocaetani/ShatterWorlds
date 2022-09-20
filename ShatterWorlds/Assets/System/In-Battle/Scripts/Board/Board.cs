using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    [HideInInspector]
    public BoardData BoardData;
    [HideInInspector]
    public Dictionary<Vector2, Square> BoardStructure;

    public BoardView BoardView;

    public Board(int size, BoardView boardView)
    {
        BoardData = new BoardData(size);
        BoardView = boardView;
        InitBoardStructure(BoardData.BoardSize);
    }

    public void InitBoardStructure(int boardSize)
    {
        BoardStructure = new Dictionary<Vector2, Square>();
        for (int i = 0; i < boardSize - 1; i++)
        {
            for (int j = 0; j < boardSize - 1; j++)
            {
                Vector2 squarePosition = new Vector2(i, j);
                Square square = InstantiateSquare(i, j);
                BoardStructure.Add(squarePosition, square);
            }
        }
    }

    public Square InstantiateSquare(float x, float z)
    {
        return SquareFactory.SpawnSquare(x, z, BoardView.gameObject);
    }

}
