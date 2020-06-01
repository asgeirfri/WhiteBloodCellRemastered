using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    GameManager GM;

    void Awake()
    {
        GM = GameManager.Instance;
        GM.OnStateChange += HandleOnStateChange;

        Debug.Log("Current game state when Awakes: " + GM.gameState);
    }

    void Start()
    {
        Debug.Log("Current game state when Starts: " + GM.gameState);
    }

    public void HandleOnStateChange()
    {
        GM.SetGameState(GameState.MAIN_MENU);
        Debug.Log("Handling state change to: " + GM.gameState);
        Invoke("LoadLevel", 3f);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Game");
    }
}