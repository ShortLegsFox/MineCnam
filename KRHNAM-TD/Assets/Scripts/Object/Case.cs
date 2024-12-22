using Interface;
using UnityEngine;

public class Case
{
    public Vector3 worldPosition;
    public int GridX;
    public int GridY;
    public I_Tower entity;
    public bool IsEmpty => entity == null;

    public Case(Vector3 _worldPos, int gridX, int gridY)
    {
        worldPosition = _worldPos;
        GridX = gridX;
        GridY = gridY;
    }
}
