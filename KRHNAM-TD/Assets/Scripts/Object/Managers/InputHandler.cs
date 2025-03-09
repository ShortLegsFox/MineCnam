using Abstract;
using UnityEngine;
using Interface;

public class InputHandler : MonoBehaviour
{
    private I_Command pauseCommand;
    private I_Command storeCommand;

    void Start()
    {
        pauseCommand = new PauseCommand();
        storeCommand = new StoreCommand();
    }

    void Update()
    {

        //Keyboard Inputs
        if (Input.GetKeyDown(KeyCode.Escape))
            pauseCommand.Execute();

        if (Input.GetKeyDown(KeyCode.Tab))
            storeCommand.Execute();

        if (Input.GetKeyDown(KeyCode.F10))
            GameManager.Instance.AccelereGame();


        //Mouse Inputs

        if (Input.GetMouseButtonDown(0) && !HudManager.Instance.StorePannel.activeSelf)
        {
            PlaceEntity();
        }

        if (Input.GetMouseButtonDown(1) && !HudManager.Instance.StorePannel.activeSelf && Grid.Instance.selectedCase.entity is Tower selectTower)
        {
            EditorManager.Instance.SetContextualTower(selectTower);
        }

        else if (Input.GetMouseButtonDown(1) && Grid.Instance.selectedCase.entity == null)
        {
            EditorManager.Instance.ClearContextualTower();
        }
    }

    public void PlaceEntity()
    {
        if (Input.GetMouseButtonDown(0) && !HudManager.Instance.StorePannel.activeSelf)
        {
            EditorManager.Instance.PlaceEntity(Grid.Instance.selectedCase);
        }
    }
}
