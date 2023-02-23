using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    private float timer = 3f;
    [SerializeField] private float tempTimer;
    [SerializeField] private TextMeshProUGUI timerText;

    private void OnEnable()
    {
        GameEvents.onGameStateChanged += Initialize;
    }

    //Initializing the variable to only work when the state is the wanted state
    private void Initialize(GameStates state)
    {
        if (state == GameStates.levelStarting)
        {
            timerText = GetComponentInChildren<TextMeshProUGUI>();
            tempTimer = timer;

            StartCoroutine("CountDown");
        }  
    }

    //Change gamestate after countdown finish
    IEnumerator CountDown()
    {
        while (tempTimer > 0)
        {
            timerText.text = ((int)tempTimer).ToString();
            yield return new WaitForSeconds(1f);
            tempTimer--;
        }

        timerText.text = "Lets Go!!!";

        yield return new WaitForSeconds(1f);

        GameStateManager.instance.ChangeGameState(GameStates.inProgress);

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameEvents.onGameStateChanged -= Initialize;
    }
}