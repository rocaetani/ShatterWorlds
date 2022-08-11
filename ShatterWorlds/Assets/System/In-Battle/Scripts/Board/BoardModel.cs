using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel
{
    public BoardSquareModel[,] BoardStructure;

    public int BoardSize;

    public BoardModel(int boardSize)
    {
        BoardSize = boardSize;
        BoardStructure = new BoardSquareModel[boardSize,boardSize];
        InitiateBoard();
        PrintBoard();
    }

    private void InitiateBoard()
    {
        for (int i = 0; i < BoardSize-1; i++)
        {
            for (int j = 0; j < BoardSize-1; j++)
            {
                BoardStructure[i,j] = new BoardSquareModel();
            }
        }
    }

    private void PrintBoard()
    {
        Debug.Log(BoardSize);
        //GameLogger.instance.Log(BoardSize+"", this);
    }
}
