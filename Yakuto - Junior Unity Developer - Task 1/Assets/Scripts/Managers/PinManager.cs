using UnityEngine;

public class PinManager : MonoBehaviour
{
    public static PinManager instance;

    private int numberOfPins = 20;
    private int numberofPinsLeft;

    public int GetPinCount
    {
        get { return numberOfPins; }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        numberofPinsLeft = numberOfPins;
    }

    private void Update()
    {
        if (numberofPinsLeft == 0)
        {
            GameStateManager.instance.ChangeGameState(GameStates.gameOver);
        }
    }

    public void ReducePinsLeft()
    {
        numberofPinsLeft--;
    }
}
