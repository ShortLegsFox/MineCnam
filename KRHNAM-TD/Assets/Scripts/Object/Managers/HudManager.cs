using Abstract;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    private static HudManager instance = null;
    public static HudManager Instance => instance;
    public static Entity selectedEntity;
    public TextMeshProUGUI Money;
    public GameObject StorePannel;
    public ItemListUI ItemListUI;
    public TextMeshProUGUI TabName;
    public GameObject PauseMenu;
    private I_Command storeCommand;
    private I_Command pauseCommand;

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

    private void Start()
    {
        storeCommand = new StoreCommand();
        pauseCommand = new PauseCommand();
    }

    private void Update()
    {
        DrawScope();
        OnEntityHover();
        UpdateMoneyText();
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
        }
    }

    public void TogglePauseMenu()
    {
        pauseCommand.Execute();
    }

    public void ToggleStorePannel()
    {
        storeCommand.Execute();
    }

    private void UpdateMoneyText()
    {
        Money.text = StoreManager.Instance.gold.ToString();
    }

    public void SelectTower(TowerData towerData)
    {
        EditorManager.Instance.SelectTower(towerData);
    }

    public void DrawScope()
    {
        Entity entity = EditorManager.Instance.selectedEntity != null ? EditorManager.Instance.selectedEntity : selectedEntity;
        if (entity is Tower tower)
        {
            float angleStep = 360f / 100; // Angle entre chaque point
            Vector3 previousPoint = tower.Position.worldPosition + new Vector3(tower.towerData.Range, 0, 0); // Premier point sur le cercle

            for (int i = 1; i <= 100; i++)
            {
                float angle = Mathf.Deg2Rad * (i * angleStep);
                Vector3 nextPoint = tower.Position.worldPosition + new Vector3(Mathf.Cos(angle) * tower.towerData.Range, 0, Mathf.Sin(angle) * tower.towerData.Range);

                Debug.DrawLine(previousPoint, nextPoint, Color.gray); // Dessine une ligne entre les points
                previousPoint = nextPoint;
            }
        }
    }


    public void OnEntityHover()
    {
        Entity entity = Grid.Instance.selectedCase?.entity;
        if (entity != null)
            selectedEntity = entity;
        else
            selectedEntity = null;
    }






}
