using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance = null;
    public static Grid Instance => instance;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    Case[,] grid;

    float nodeDiameter;
    int gridSizeX, gridSizeY;
    public Case selectedCase;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void Update()
    {
        UpdateSelectedCase();
        DisplaySelectedObject();
    }


    void DisplaySelectedObject()
    {
        if (EditorManager.Instance.IsEntitySelected)
        {
            if (selectedCase != null && selectedCase.IsEmpty)
                EditorManager.Instance.selectedEntity.OnPlace(selectedCase.worldPosition);
            else
                EditorManager.Instance.selectedEntity.OnPlace(new Vector3(-1000, -1000, -1000));
        }
    }


    void UpdateSelectedCase()
    {
        Plane gridPlane = new Plane(Vector3.up, Vector3.zero); // Plan horizontal (XZ)
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (gridPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            selectedCase = CaseFromWorldPoint(hitPoint);
            //Debug.Log($"Case sélectionnée : [{selectedCase.GridX}; {selectedCase.GridY}] : {selectedCase.IsEmpty} - {selectedCase.entity != null}");
        }
        else
        {
            selectedCase = null;
        }
    }


    void CreateGrid()
    {
        grid = new Case[gridSizeX, gridSizeY];
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
                grid[x, y] = new Case(worldPoint, x, y);

                Collider[] colliders = Physics.OverlapSphere(worldPoint, nodeRadius);
                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag("Obstacle"))
                    {
                        grid[x, y].isBlocked = true;
                        break;
                    }
                }
            }
        }
    }


    public Case CaseFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.FloorToInt((gridSizeX) * percentX); // Utilisez FloorToInt pour éviter les chevauchements
        int y = Mathf.FloorToInt((gridSizeY) * percentY);

        return grid[Mathf.Clamp(x, 0, gridSizeX - 1), Mathf.Clamp(y, 0, gridSizeY - 1)];
    }


    private void OnDrawGizmos()
    {

        if (!Application.isPlaying)
            return;

        if (GameManager.Instance != null && GameManager.Instance.DebugMode)
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));

            if (grid != null)
            {
                foreach (Case c in grid)
                {
                    if (!c.IsEmpty)
                        Gizmos.color = Color.red;
                    else if (c == selectedCase)
                        Gizmos.color = Color.blue;
                    else
                        Gizmos.color = Color.white;

                    Gizmos.DrawCube(c.worldPosition, Vector3.one * (nodeDiameter - 0.1f));
                }
            }
        }
    }

}
