using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareData
{
    public Vector2 Position;

    public Attachable ObjectAttached;

    public SquareData(float x, float z)
    {
        Position = new Vector2(x, z);
    }
}
