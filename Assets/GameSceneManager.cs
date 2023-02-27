using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public int MenuScene;
    public int LevelOneScene;
    public int WinMenuScene;
    public int DeadMenuScene;

    // Start is called before the first frame update
    void Start()
    {
        MenuScene = Config.MenuScene;
        LevelOneScene = Config.LevelOneScene;
        DeadMenuScene = Config.DeadMenu;
        WinMenuScene = Config.WinMenu;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel1()
    {     
        SceneManager.LoadScene(LevelOneScene);
    }     
          
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MenuScene);

    }

    public void LoadWinMenu()
    {
        SceneManager.LoadScene(WinMenuScene);
    }

    public void LoadDeadMenu()
    {
        SceneManager.LoadScene(DeadMenuScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
