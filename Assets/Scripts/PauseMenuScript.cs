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

    public GameObject newGameMenu;
    public GameObject map;
    public GameObject player;
    public TMP_InputField inputField;
    public Toggle randomSeed;
    public static bool random;
    public static float seed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //gameIsPaused = !gameIsPaused;
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

    public void PlayGame()
    {
        random = randomSeed;

        if (randomSeed == true)
        {
            map.SetActive(true);
        }
        else
        {
            string seedString = inputField.text;
            seed = float.Parse(seedString);
            print(seedString);
        }
        newGameMenu.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
