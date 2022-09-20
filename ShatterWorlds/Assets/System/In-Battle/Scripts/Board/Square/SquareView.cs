using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareView : MonoBehaviour
{
    public void RenameSquare(float x, float z)
    {
        gameObject.name = $"Square {x} {z} ";
    }
}
