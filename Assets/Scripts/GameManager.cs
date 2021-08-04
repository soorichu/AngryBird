using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Text.RegularExpressions;


public class GameManager : MonoBehaviour
{
    public static GameManager singleton;
    public bool isGameover = false;
    
    public GameObject gameoverText;
    public GameObject youwinText;

    string sceneName = "Level1";
    int level = 1;
    public Text levelText;
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        level = int.Parse(Regex.Replace(sceneName, @"[^0-9]", ""));
        levelText.text = "Level" + level;

    }

    void Update()
    {
        if (GameManager.singleton != null) return;
        else
            GameManager.singleton = this;

    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoNextLevel()
    {
        try
        {
            SceneManager.LoadScene("Level" + (level+1));
        }
        catch (System.Exception e)
        {
            GameRestart();
        }
        
    }
}
