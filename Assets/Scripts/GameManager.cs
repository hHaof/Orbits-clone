using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            init();
            return;
        }
        else{
            Destroy(gameObject);
        }

    }

    public bool IsInitialized{get; set;}
    public int CurrentScore{get; set;}

    private string highScoreKey = "HighScore";

    public int HighScore{
        get{
            return PlayerPrefs.GetInt(highScoreKey, 0);
        }
        set{
            PlayerPrefs.GetInt(highScoreKey, value);
        }
    }

    void init(){
        IsInitialized = false;
        CurrentScore = 0;
    }

    private const string MainMenu = "MainMenu";
    private const string GamePlay = "GamePlay";


    public void GoToMainMenu(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
    }
    public void GotoGamePlay(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(GamePlay);
    }

}
