using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject saveMenu;
    public GameObject optionsMenu;
    public GameObject buildMenuController;
    public static bool gameIsPaused = false;

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
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (gameIsPaused == false)
        {
            pauseMenu.SetActive(true);
            buildMenuController.SetActive(false);
            gameIsPaused = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            buildMenuController.SetActive(true);
            gameIsPaused = false;
        }
    }

    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        buildMenuController.SetActive(true);
        gameIsPaused = false;
    }

    public void SaveGame()
    {
        gameIsPaused = true;
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
