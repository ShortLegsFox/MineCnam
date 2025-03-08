using UnityEngine;
using Interface;

public class StoreCommand : I_Command
{
    private GameObject storeMenu;

    public StoreCommand()
    {
        storeMenu = HudManager.Instance.StorePannel;
    }

    public void Execute()
    {
        bool isActive = storeMenu.activeSelf;
        storeMenu.SetActive(!isActive);
        //Time.timeScale = isActive ? 1 : 0;
    }
}