using UnityEngine;

[CreateAssetMenu(fileName = "StoreArticle", menuName = "Scriptable Objects/StoreArticle")]
public class StoreArticle : ScriptableObject
{
    public Entity Article;
    public int Price;
    public Sprite Image;

}
