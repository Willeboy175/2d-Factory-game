using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject saveMenu;
    public GameObject optionsMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("GameScene");
        print("NewGame");
    }

    public void LoadGame()
    {
        mainMenu.SetActive(false);
        saveMenu.SetActive(true);
        print("LoadGame");
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        print("Options");
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        saveMenu.SetActive(false);
        print("Back");
    }

    public void ExitGame()
    {
        Application.Quit();
        print("ExitGame");
    }
}