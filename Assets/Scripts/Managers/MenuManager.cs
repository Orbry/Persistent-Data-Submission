using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : Singleton<MenuManager>
{
    public GameObject highscore;
    public GameObject highscoreFull;
    public GameObject menu;
    public string playerName;
    
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void UpdatePlayerName(string playerName)
    {
        this.playerName = playerName;
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    
    public void ToggleHighscores()
    {
        menu.SetActive(!menu.activeSelf);
        highscore.SetActive(!highscore.activeSelf);
        highscoreFull.SetActive(!highscoreFull.activeSelf);
    }
}
