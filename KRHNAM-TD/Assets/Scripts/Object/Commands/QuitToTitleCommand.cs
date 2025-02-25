using UnityEngine.SceneManagement;

public class QuitToTitileCommand : I_Command
{

    public QuitToTitileCommand() { }

    public void Execute()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
