using Interface;

public class RestartCommand : I_Command
{
    public RestartCommand()
    {
    }

    public void Execute()
    {
        //GameManager.Instance.Castle.GetComponent<Castle>().ResetCastle();
        //GameManager.Instance.WaveManager.ResetWave();
        //GameManager.Instance.HudManager.GameOverMenu.SetActive(false);
        //GameManager.Instance.HudManager.PauseMenu.SetActive(false);
        //Time.timeScale = 1;
    }
}
