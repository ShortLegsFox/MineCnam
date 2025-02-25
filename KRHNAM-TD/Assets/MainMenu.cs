using System.Collections.Generic;
using System.Linq;
using TDObject.HUD;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneAsset gameScene;
    public GameObject menuPannel;
    public GameObject leaderboardPannel;
    public GameObject scorePannel;
    public void Start()
    {
        LoadScores();
    }


    public void PlayGame()
    {
        // Changement de scene pour game
        SceneManager.LoadScene(gameScene.name);
    }

    public void OpenLeaderBoard()
    {
        menuPannel.SetActive(false);
        leaderboardPannel.SetActive(true);
    }

    public void OpenMenu()
    {
        menuPannel.SetActive(true);
        leaderboardPannel.SetActive(false);
    }


    public void LoadScores()
    {
        Score[] scores = GetTop5Scores();

        foreach (var score in scores.Select((score, index) => (score, index)))
        {
            int rank = score.index + 1;
            SetPannelPlayer(rank, score.score);
        }

    }

    public void SetPannelPlayer(int rank, Score score)
    {
        if (rank < 0 || rank > 5)
            throw new System.Exception("Rank must be between 0 and 5");


        Transform playerPannel = scorePannel.transform.Find($"Player{rank}Pannel");
        if (playerPannel != null)
        {
            playerPannel.Find("PlayerLabel").GetComponent<TMPro.TextMeshProUGUI>().text = score.PlayerName;
            playerPannel.Find("NbMancheLabel").GetComponent<TMPro.TextMeshProUGUI>().text = score.Points.ToString();
        }
        else
            throw new System.Exception($"Player{rank}Pannel not found");

    }

    private Score[] GetTop5Scores()
    {
        List<Score> allScores = new List<Score>()
        {
            new Score("Player1", 500),
            new Score("Player2", 100),
            new Score("Player3", 100),
            new Score("Player4", 400),
            new Score("Player5", 100),
            new Score("Player6", 600),
            new Score("Player7", 800),
            new Score("Player8", 100),
            new Score("Player9", 4000),
            new Score("Player10", 40),
        };

        return allScores.OrderByDescending(score => score.Points).Take(5).ToArray();
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
