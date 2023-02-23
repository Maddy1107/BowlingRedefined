using System;
using UnityEngine;

[Serializable]
public class PlayerStats : MonoBehaviour
{
    #region Variables
    public static PlayerStats instance;

    private PlayerDataBase playerData;

    private int currentScore;
    private int highScore;

    #endregion

    #region Getter

    public int GetHighScore
    {
        get { return highScore; }
    }

    public int GetCurrentScore
    {
        get { return currentScore; }
    }
    #endregion

    #region Start/Awake
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        GameLoad();
    }

    #endregion

    #region Save/Load
    public void GameSave()
    {
        if(currentScore > highScore)
            highScore = currentScore;
        SaveManager.instance.SaveGame(this);
    }

    public void GameLoad()
    {
        playerData = SaveManager.instance.LoadGame();
        SetPlayerData();
    }
    #endregion

    #region Set/Reset PlayerData
    public void SetPlayerData()
    {
        highScore = playerData.highScore;
    }

    public void ResetPlayerdata()
    {
        highScore = 0;
        GameSave();
    }
    #endregion

    #region Update Values

    public void AddScore(int amount)
    {
        currentScore = amount;
    }

    #endregion
}