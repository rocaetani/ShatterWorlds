using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public BoardModel BoardModel;

    public void InitBoard(int seed)
    {
        BoardModel = new BoardModel(seed);
    }

    private void Awake()
    {
        BoardNetwork.BoardController = this;
    }
}
