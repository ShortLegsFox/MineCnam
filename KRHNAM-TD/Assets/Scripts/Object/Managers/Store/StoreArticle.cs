using UnityEngine;

[CreateAssetMenu(fileName = "StoreArticle", menuName = "Scriptable Objects/StoreArticle")]
public class StoreArticle : ScriptableObject
{
    public Entity Article;
    public string Name;
    public int Price;
    public Sprite Image;
    public Element Element;
    public TowerLevel Level;
}
