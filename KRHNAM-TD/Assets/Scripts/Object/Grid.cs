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
    private Case selectedCase;

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
    }


    void UpdateSelectedCase()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            selectedCase = CaseFromWorldPoint(hit.point);
            //Debug.Log($"[{selectedCase.GridX};{selectedCase.GridY}]");
        }
        else
            selectedCase = null;

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
            }
        }
    }


    public Case CaseFromWorldPoint(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
        float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((gridSizeY - 1) * percentY);
        return grid[x, y];
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
