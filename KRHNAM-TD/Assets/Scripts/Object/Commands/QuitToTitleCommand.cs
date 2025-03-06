using UnityEngine.SceneManagement;

public class QuitToTitileCommand : I_Command
{

    public QuitToTitileCommand() { }

    public void Execute()
    {
        GameManager.Instance.SaveScore();
        SceneManager.LoadScene("MainMenu");
    }
}
