using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private bool hasGameStarted;

    private float timer = 10;
    private float tempTimer;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image timerImage;
    [SerializeField] private Image clockImage;

    private void OnEnable()
    {
        GameEvents.onGameStateChanged += Initialize;
    }

    private void Initialize(GameStates state)
    {
        tempTimer = timer;
        hasGameStarted = state == GameStates.inProgress;
        if(state == GameStates.levelStarting)
            clockImage.gameObject.SetActive(true);
    }

    public void Update()
    {
        if (!hasGameStarted)
            return;

        tempTimer -= Time.deltaTime;
        timerText.text = ((int)tempTimer).ToString();
        timerImage.fillAmount = tempTimer/timer;

        if (tempTimer <= 0)
            GameStateManager.instance.ChangeGameState(GameStates.gameOver);
    }

    private void OnDisable()
    {
        GameEvents.onGameStateChanged -= Initialize;
    }
}
