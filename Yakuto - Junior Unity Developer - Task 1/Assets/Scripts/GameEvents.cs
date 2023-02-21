using System;

public class GameEvents
{
    public static Action<GameStates> onGameStateChanged;//Used to check if the game state is changed
    public static Action<int> onScoreChanged;//Change variable and UI when scorechanged
}
