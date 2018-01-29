using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    [SerializeField] private static bool GamePaused = false; //Pause State
    [SerializeField] private string MenuName; //Scene to load
    [SerializeField] private ExhaustionBar ExhaustionBar;

    public GameObject PauseMenu;  //The Menu UI Window
    public GameObject GameOverMenu;
	
	void Update () {
    
	    if(ExhaustionBar.maxExhaustion()) {
	            GameOver();
	    }

		if(Input.GetKeyDown(KeyCode.Escape)){
            if (GamePaused){
                Resume();
            }
            else{
                PauseGame();
            }
        }        
	}

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    void GameOver()
    {
        GameOverMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = false;
    }

    public void MainMenu()
    {
        GamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(MenuName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
