using UnityEngine;

public class Case
{
    public Vector3 worldPosition;
    public int GridX;
    public int GridY;
    public Entity entity;
    public bool isBlocked;
    public bool IsEmpty => entity == null && isBlocked == false;

    public Case(Vector3 _worldPos, int gridX, int gridY)
    {
        worldPosition = _worldPos;
        GridX = gridX;
        GridY = gridY;
    }
}
