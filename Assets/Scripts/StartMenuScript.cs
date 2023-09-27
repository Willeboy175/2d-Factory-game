using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    public GameObject newGameMenu;
    public GameObject pauseMenuController;
    public GameObject BuildMenuController;
    public GameObject map;
    public TMP_InputField inputField;
    public Toggle randomSeed;
    public static bool random;
    public static float seed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMainMenu();
        }
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
        pauseMenuController.SetActive(true);
        BuildMenuController.SetActive(true);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
