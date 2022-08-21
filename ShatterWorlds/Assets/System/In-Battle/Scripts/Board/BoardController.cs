using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [HideInInspector]
    public BoardModel BoardModel;
    [HideInInspector]
    public Dictionary<Vector2, SquareController> BoardStructure;


    private GameObject _squarePrefab;

    public void InitBoard(int seed)
    {
        BoardModel = new BoardModel(seed);
        _squarePrefab = Resources.Load<GameObject>("InBattle/Prefabs/Square");

        InitBoardStructure(BoardModel.BoardSize);
    }
    
    public void InitBoardStructure(int boardSize)
    {
        BoardStructure = new Dictionary<Vector2, SquareController>();
        for (int i = 0; i < boardSize-1; i++)
        {
            for (int j = 0; j < boardSize-1; j++)
            {
                Vector2 squarePosition = new Vector2(i,j);
                SquareController squareController = InstantiateSquare(i, j);
                BoardStructure.Add(squarePosition, squareController);
            }
        }
    }

    public SquareController InstantiateSquare(float x, float z)
    {
        GameObject square = Instantiate(_squarePrefab, new Vector3(x, 0, z), Quaternion.identity, gameObject.transform);
        SquareController squareController = square.GetComponent<SquareController>();
        squareController.InitializeSquare(x, z);
        return squareController;
    }

    private void Awake()
    {
        BoardNetwork.BoardController = this;
    }
}
