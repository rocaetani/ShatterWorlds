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

    public Attachable GetObjectAttached()
    {
        return SquareData.ObjectAttached;
    }

    public void AttachObject(Attachable objectAttachable)
    {
        SquareData.ObjectAttached = objectAttachable;
    }

}
