using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIManager : MonoBehaviour
{
    public GameObject highscore;
    public GameObject highscoreFull;
    public GameObject menu;
    public TMP_InputField nameInput;
    
    private void Start()
    {
        // TODO: get highscores from HighscoreManager and display them

        string playerName = PlayerManager.Instance.playerName;
        if (playerName != "")
        {
            nameInput.text = playerName;
        }
    }

    public void UpdatePlayerName(string playerName)
    {
        PlayerManager.Instance.playerName = playerName;
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
