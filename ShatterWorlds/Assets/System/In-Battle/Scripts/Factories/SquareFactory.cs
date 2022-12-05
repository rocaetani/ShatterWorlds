using UnityEngine;
public class SquareFactory
{
    private static readonly GameObject squarePrefab = Resources.Load<GameObject>("InBattle/Prefabs/Square");

    public static Square SpawnSquare(float x, float z, GameObject parent)
    {
        SquareView squareView = SpawnSquareGameObject(x, z, parent);
        return new Square(x, z, squareView);
    }

    private static SquareView SpawnSquareGameObject(float x, float z, GameObject parent)
    {
        //GameObject squarePrefab = Resources.Load<GameObject>("InBattle/Prefabs/Square");
        GameObject squareSpawned = Object.Instantiate(squarePrefab, new Vector3(x, 0, z), Quaternion.identity, parent.transform);
        SquareView squareView = squareSpawned.GetComponent<SquareView>();
        return squareView;
    }
}
