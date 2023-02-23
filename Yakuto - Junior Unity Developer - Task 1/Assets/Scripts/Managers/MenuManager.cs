using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject pauseMenu;

    private void OnEnable()
    {
        GameEvents.onGameStateChanged += CheckState;
    }

    //Check if game over after the gamestatechange even is thrown
    private void CheckState(GameStates state)
    {
        if(state == GameStates.gameOver)
            GameOver();
    }

    //Activates when game paused.
    //The bool checks if the player is pausing or unpausing
    //to change the state of the game
    public void PauseGame(bool unpause)
    {
        if (unpause)
        {
            GameStateManager.instance.ChangeGameState(GameStates.inProgress);
            pauseMenu.SetActive(false);
        }
        else
        {
            GameStateManager.instance.ChangeGameState(GameStates.paused);
            pauseMenu.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManagerScript.instance.Load(Scenes.Game);
    }

    public void MainMenu()
    {
        SceneManagerScript.instance.Load(Scenes.MainMenu);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }
}
