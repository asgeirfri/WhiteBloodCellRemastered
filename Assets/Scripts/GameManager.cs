using UnityEngine;
using System.Collections;

// Game States
// for now we are only using these two
public enum GameState { GAME, MAIN_MENU }

public delegate void OnStateChangeHandler();

// https://hub.packtpub.com/creating-simple-gamemanager-using-unity3d/
public class GameManager
{
    protected GameManager() { }
    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }

    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                //Object.DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }

    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        Debug.Log("J'aja vinur");
        OnStateChange();
    }

    public void OnApplicationQuit()
    {
        GameManager.instance = null;
    }

}
