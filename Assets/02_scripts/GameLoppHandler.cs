using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoppHandler : MonoBehaviour
{
    [SerializeField] bool isGameRunning = false; //if needed ctrl r r will change all the names that are the same 
    [SerializeField] GameObject gameOverPanel;
    
    // Start is called before the first frame update

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isGameRunning)                      this can be used but is performance expensive
        {

        }
        else if (!isGameRunning)
        {
            FinishGame();
        }*/
    }

    public void StartGame()
    {
        Time.timeScale = 1f; //so the game goes normally if placed at 0 game stops at 0.2 games slows
        isGameRunning = true;
        Debug.Log("Started");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void FinishGame()
    {
        isGameRunning = false;
        PauseGame();
        gameOverPanel.SetActive(true);
        Debug.Log("Finished");
    }

    public void RealoadLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("01_MainMenu");
    }
}
