using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    [HideInInspector]
    public SquareModel SquareModel;

    [HideInInspector]
    public SquareView SquareView;
    // Start is called before the first frame update
    public void InitializeSquare(float x, float z)
    {
        SquareModel = new SquareModel(x, z);
        SquareView = gameObject.GetComponent<SquareView>();
        RenameSquare();

    }

    public void RenameSquare()
    {
        gameObject.name = $"Square {SquareModel.Position.x} {SquareModel.Position.y} ";
    }
    
}
