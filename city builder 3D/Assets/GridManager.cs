using UnityEngine;

public class GridManager : MonoBehaviour {

    public int width = 10;
    public int height = 10;
    public float cellSize = 1f;

    public Vector3 getNearsestPointOnGrid(Vector3 position) {
        float x = Mathf.Round(position.x / cellSize) * cellSize;
        float z = Mathf.Round(position.z / cellSize) * cellSize;
        return new Vector3(x, 0, z);
    }
}