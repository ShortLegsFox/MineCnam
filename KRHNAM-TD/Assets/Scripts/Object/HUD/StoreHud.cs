using TMPro;
using UnityEngine;

public class StoreHud : MonoBehaviour
{

    public ItemListUI ItemListUI;
    public TextMeshProUGUI TabName;

    public void Awake()
    {
        ItemListUI.PopulateList(Element.Fire);
        TabName.text = "Fire Towers";
    }

    public void OpenTab(string element)
    {
        HudManager.Instance.ToggleStorePannel();
        SelectTab(element);
    }

    public void SelectTab(string element)
    {
        switch (element)
        {
            case "Fire":
                ItemListUI.PopulateList(Element.Fire);
                TabName.text = "Fire Towers";
                break;
            case "Water":
                ItemListUI.PopulateList(Element.Water);
                TabName.text = "Water Towers";
                break;
            case "Earth":
                ItemListUI.PopulateList(Element.Earth);
                TabName.text = "Earth Towers";
                break;
            case "Wood":
                ItemListUI.PopulateList(Element.Wood);
                TabName.text = "Wood Towers";
                break;
            case "Metal":
                ItemListUI.PopulateList(Element.Metal);
                TabName.text = "Metal Towers";
                break;
        }
    }
}
