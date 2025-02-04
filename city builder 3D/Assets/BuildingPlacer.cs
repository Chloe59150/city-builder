using UnityEngine;

public class BuildingPlacer : MonoBehaviour {

    public GameObject buildingPrefab;
    private GameObject previewBuilding;
    private GridManager gridManager;

    void Start() {
        gridManager = FindObjectOfType<GridManager>();

        previewBuilding = Instantiate(buildingPrefab);
        previewBuilding.GetComponent<Collider>().enabled = false;
        previewBuilding.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 0.5f);
    }

    void Update() {
        Vector3 mousePos = GetMouseWorldPosition();
        Vector3 gridPos = gridManager.getNearsestPointOnGrid(mousePos);

        previewBuilding.transform.position = gridPos;

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(buildingPrefab, gridPos, Quaternion.identity);
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit)) {
            return hit.point;
        }
        return Vector3.zero;
    }
}