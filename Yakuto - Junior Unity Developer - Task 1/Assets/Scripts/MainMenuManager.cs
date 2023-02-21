using UnityEngine;
using TMPro;
using System;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScore;

    private void Start()
    {
        ShowHighScore();
    }

    private void ShowHighScore()
    {
        highScore.text = PlayerStats.instance.GetHighScore.ToString();
    }

    public void StartGame()
    {
        GameStateManager.instance.ChangeGameState(GameStates.levelStarting);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
