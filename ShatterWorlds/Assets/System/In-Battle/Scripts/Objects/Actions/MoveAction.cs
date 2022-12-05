using System.Collections.Generic;
using UnityEngine;
public class MoveAction
{
    public List<Vector2> PathList;

    public MoveAction()
    {
        PathList = new List<Vector2>();
    }

    public void AddSquare(Vector2 square)
    {
        PathList.Add(square);
    }

}
