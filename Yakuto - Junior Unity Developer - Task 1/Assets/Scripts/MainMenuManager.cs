using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        GameStateManager.instance.ChangeGameState(GameStates.levelStarting);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
