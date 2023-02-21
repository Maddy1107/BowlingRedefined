using UnityEngine;
using TMPro;

public class LevelDataTracker : MonoBehaviour
{
    public static LevelDataTracker instance;

    [Header("Level Data")]
    private int currentScore;
    private int highScore;

    [Header("Level UI")]
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        GameEvents.onGameStateChanged += SaveToPlayerStates;
    }

    private void Awake()
    {
        instance = this;
    }

    private void SaveToPlayerStates(GameStates state)
    {
        if(state == GameStates.gameOver)
        {
            PlayerStats.instance.AddScore(currentScore);
            PlayerStats.instance.GameSave();
        }
        else if(state == GameStates.levelStarting)
        {
            highScore = PlayerStats.instance.GetHighScore;
            highScoreText.text = highScore.ToString();
        }
    }

    public void ChangeText(bool hasHighscoreChanged)
    {
        currentScoreText.text = currentScore.ToString();
        if (hasHighscoreChanged)
            highScoreText.text = currentScore.ToString();
    }

    public void ChangeScore(int amount)
    {
        currentScore += amount;
        if (currentScore > highScore)
            ChangeText(true);
        else
            ChangeText(false); 
    }

    private void OnDisable()
    {
        GameEvents.onGameStateChanged -= SaveToPlayerStates;
    }
}
