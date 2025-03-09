using UnityEngine;
using Interface;

public class PauseCommand : I_Command
{
    private GameObject pauseMenu;

    public PauseCommand()
    {
        pauseMenu = HudManager.Instance.PauseMenu;
    }

    public void Execute()
    {
        bool isActive = pauseMenu.activeSelf;
        pauseMenu.SetActive(!isActive);
        Time.timeScale = isActive ? 1 : 0;
    }
}