using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject saveMenu;
    public GameObject optionsMenu;
    public static bool gameIsPaused;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (saveMenu.activeSelf == true || optionsMenu.activeSelf == true)
            {
                Back();
            }
            else
            {
                gameIsPaused = !gameIsPaused;
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }

    public void ContinueGame()
    {
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
