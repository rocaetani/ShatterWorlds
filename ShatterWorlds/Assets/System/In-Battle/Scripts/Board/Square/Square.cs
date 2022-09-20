using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square
{
    private SquareData SquareData;

    private SquareView SquareView;


    public Square(float x, float z, SquareView squareView)
    {
        SquareData = new SquareData(x, z);
        SquareView = squareView;
        squareView.RenameSquare(x, z);
    }

}
