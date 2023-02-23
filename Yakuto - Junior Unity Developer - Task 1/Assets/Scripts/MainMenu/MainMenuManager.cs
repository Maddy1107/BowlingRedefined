using UnityEngine;
using TMPro;

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
        SceneManagerScript.instance.Load(Scenes.Game);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
