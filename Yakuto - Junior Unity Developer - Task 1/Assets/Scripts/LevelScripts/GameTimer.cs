using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private bool hasGameStarted;

    private float timer = 30f;
    private float tempTimer;

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image timerImage;
    [SerializeField] private Image clockImage;

    private void OnEnable()
    {
        GameEvents.onGameStateChanged += Initialize;
    }

    private void Start()
    {
        tempTimer = timer;
    }

    private void Initialize(GameStates state)
    {
        hasGameStarted = state == GameStates.inProgress;
        if(state == GameStates.levelStarting)
        {
            timerText.text = ((int)tempTimer).ToString();
            clockImage.gameObject.SetActive(true);
        }
    }

    //Countdown of teh given interval
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
