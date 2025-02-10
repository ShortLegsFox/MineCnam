using UnityEngine;

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

        //Mouse Inputs

        if (Input.GetMouseButtonDown(0) && !HudManager.Instance.StorePannel.activeSelf)
        {
            PlaceEntity();
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
