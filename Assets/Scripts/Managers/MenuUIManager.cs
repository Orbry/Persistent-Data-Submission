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
    
    public GameObject HighscoresShort;
    public GameObject HighscoresFull;
    public GameObject MainMenu;
    public Transform HighscoresShortWrapper;
    public Transform HighscoresFullWrapper;
    public TMP_InputField nameInput;

    public GameObject HighscoreShortPrefab;
    public GameObject HighscoreFullPrefab;

    const int HS_SHORT_COUNT = 3;
    const int HS_SHORT_VERTICAL_START = 85;
    const int HS_SHORT_VERTICAL_STEP = 50;
    const int HS_FULL_VERTICAL_START = 190;
    const int HS_FULL_VERTICAL_STEP = 35;
    
    private void Start()
    {
        SetHighscores();
        SetPlayerName();
    }
    
    private void SetHighscores()
    {
        Highscore[] scores = HighscoreManager.Instance.Highscores;

        // Short highscores
        for (int i = 0; i < HS_SHORT_COUNT; i++)
        {
            GameObject score = GameObject.Instantiate(HighscoreShortPrefab);
            
            score.transform.SetParent(HighscoresShortWrapper);
            score.transform.localPosition = new Vector3(0, HS_SHORT_VERTICAL_START - i * HS_SHORT_VERTICAL_STEP, 0);
            
            TMP_Text text = score.GetComponent<TMP_Text>();
            text.text = scores[i].ToString();

        }
        
        // Full highscores
        for (int i = 0; i < scores.Length; i++)
        {
            GameObject score = GameObject.Instantiate(HighscoreFullPrefab);

            score.transform.SetParent(HighscoresFullWrapper);
            score.transform.localPosition = new Vector3(0, HS_FULL_VERTICAL_START - i * HS_FULL_VERTICAL_STEP, 0);

            TMP_Text text = score.GetComponent<TMP_Text>();
            text.text = scores[i].ToString();
        }
    }
    
    private void SetPlayerName()
    {
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
        MainMenu.SetActive(!MainMenu.activeSelf);
        HighscoresShort.SetActive(!HighscoresShort.activeSelf);
        HighscoresFull.SetActive(!HighscoresFull.activeSelf);
    }
}
