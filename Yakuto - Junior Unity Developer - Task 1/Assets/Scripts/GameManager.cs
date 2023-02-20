using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    private PlayerControl playerControl;

    // score
    private int  v;
    private bool hasGameStarted = false;

    void Update()
    {
        if (!hasGameStarted)
            return;

        // if the player falls off the map, end the game
        if (playerControl.transform.position.y < 0f)
            EndGame();
    }

    //End the game and restart the scene 
    public void EndGame()
    {
        hasGameStarted           = false;
        playerControl.canMove = false;

        Invoke(nameof(Restart), 3);
    }

    //Restart the scene
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Add score to the game
    public void AddScore()
    {
        v += 5;
        score.text = v.ToString();
    }
}
