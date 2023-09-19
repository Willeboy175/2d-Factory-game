using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuScript : MonoBehaviour
{
    public GameObject newGameMenu;
    public GameObject map;
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
