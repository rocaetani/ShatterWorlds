using UnityEngine;
public class BoardFactory
{
    public static Board SpawnBoard(int size)
    {
        BoardView boardView = SpawnBoardGameObject();
        return new Board(size, boardView);
    }

    private static BoardView SpawnBoardGameObject()
    {
        GameObject boardSpawned = new GameObject();
        boardSpawned.name = "Board Bucket";
        BoardView boardView = boardSpawned.AddComponent<BoardView>();
        return boardView;
    }
}
