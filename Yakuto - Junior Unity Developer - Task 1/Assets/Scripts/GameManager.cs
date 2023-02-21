using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(PlayerStats.instance.GetHighScore);
    }
}
