using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject saveMenu;
    public GameObject optionsMenu;
    public bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            //Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            //Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void ContinueGame()
    {
        //Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void SaveGame()
    {
        pauseMenu.SetActive(false);
        saveMenu.SetActive(true);
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Back()
    {
        pauseMenu.SetActive(true);
        saveMenu.SetActive(false);
        optionsMenu.SetActive(false);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
