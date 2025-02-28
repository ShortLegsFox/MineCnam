using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemListUI : MonoBehaviour
{
    public GameObject ArticlePannel;


    public void PopulateList(Element targetElement = Element.Water)
    {
        ClearList();

        foreach (var item in StoreManager.Instance.StoreArticles.Where(element => element.Element == targetElement).OrderBy(element => element.Price))
        {
            GameObject newArticle = Instantiate(ArticlePannel, transform);
            Transform name = GetChildrenByName(newArticle, "Name");
            Transform price = GetChildrenByName(newArticle, "Price");
            Transform image = GetChildrenByName(newArticle, "Image");

            name.GetComponent<TextMeshProUGUI>().text = item.Name;
            price.GetComponent<TextMeshProUGUI>().text = item.Price.ToString();
            image.GetComponent<Image>().sprite = item.Image;

            Button button = newArticle.GetComponent<Button>();
            button.onClick.AddListener(() => BuyItem(item));

            // Ajout d'une gestion des événements pour changer le curseur
            AddCursorChangeHandler(newArticle, item);
            DisplayButton dpBtn = newArticle.GetComponent<DisplayButton>();
            dpBtn.Item = item;
        }
    }

    void BuyItem(StoreArticle item)
    {
        if (StoreManager.Instance.Buy(item))
        {
            HudManager.Instance.ToggleStorePannel();
        }
        else
        {
            Debug.Log("Achat impossible");
        }
    }

    void AddCursorChangeHandler(GameObject article, StoreArticle item)
    {
        EventTrigger trigger = article.AddComponent<EventTrigger>();

        // Événement OnPointerEnter
        EventTrigger.Entry pointerEnter = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerEnter
        };
        pointerEnter.callback.AddListener((data) => OnPointerEnter(item));
        trigger.triggers.Add(pointerEnter);

        // Événement OnPointerExit
        EventTrigger.Entry pointerExit = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerExit
        };
        pointerExit.callback.AddListener((data) => OnPointerExit());
        trigger.triggers.Add(pointerExit);
    }

    void OnPointerEnter(StoreArticle item)
    {
        //Debug.Log("Pointer enter");
        if (!StoreManager.Instance.CanAfford(item.Price))
        {
            CursorManager.Instance.SetBlockedCursor();
        }
    }

    void OnPointerExit()
    {
        CursorManager.Instance.SetDefaultCursor();
    }

    Transform GetChildrenByName(GameObject gameObject, string name)
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.name == name)
            {
                return child;
            }
        }
        return null;
    }

    void ClearList()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
