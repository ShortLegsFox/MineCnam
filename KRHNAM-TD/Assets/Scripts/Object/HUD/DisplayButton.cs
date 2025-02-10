using UnityEngine;
using UnityEngine.UI;

public class DisplayButton : MonoBehaviour
{
    public StoreArticle Item;
    private Color originalColor;
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
        if (image != null)
            originalColor = image.color;
    }
    void Update()
    {
        if (image != null)
        {
            if (Item != null && !StoreManager.Instance.CanAfford(Item))
            {
                image.color = Color.red;
            }
            else
            {
                image.color = originalColor;
            }
        }
    }
}
