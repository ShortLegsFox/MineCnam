using UnityEngine;

public class GameOverCommand : I_Command
{

    private GameObject gameOverMenu;

    public GameOverCommand()
    {
        gameOverMenu = HudManager.Instance.GameOverMenu;
    }

    public void Execute()
    {
        bool isActive = gameOverMenu.activeSelf;
        gameOverMenu.SetActive(!isActive);
        Time.timeScale = isActive ? 1 : 0;
    }

}
