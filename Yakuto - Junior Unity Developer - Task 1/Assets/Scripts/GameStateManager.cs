using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    public GameStates gameState;

    private void Awake() => instance = this;

    //Setting the game state to the first and initial state.
    private void Start()
    {
        ChangeGameState(GameStates.menu);
    }

    //Sending the gamestate to all the subscribers.
    public void ChangeGameState(GameStates state)
    {
        gameState = state;
        GameEvents.onGameStateChanged.Invoke(state);
    }

    public GameStates GetCurrentGameState()
    {
        return gameState;
    }
}

//All the game states.
public enum GameStates
{
    menu,
    levelStarting,
    inProgress,
    paused,
    gameOver,
}