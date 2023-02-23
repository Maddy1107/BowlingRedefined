using System;

[Serializable]
public class PlayerDataBase
{
    public int highScore;

    public PlayerDataBase(PlayerStats stats)
    {
        highScore = stats.GetHighScore;
    }
}