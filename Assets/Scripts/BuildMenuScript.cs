using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenuScript : MonoBehaviour
{
    public GameObject playerUI;
    public GameObject buildMenu;
    public GameObject pauseMenuController;
    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            BuildMenu();
        }
    }

    public void BuildMenu()
    {
        if (active == false)
        {
            buildMenu.SetActive(true);
            pauseMenuController.SetActive(false);
            playerUI.SetActive(false);
            active = true;
        }
        else
        {
            buildMenu.SetActive(false);
            pauseMenuController.SetActive(true);
            playerUI.SetActive(true);
            active = false;
        }
    }

    public void Close()
    {
        buildMenu.SetActive(false);
        pauseMenuController.SetActive(true);
        playerUI.SetActive(true);
        active = false;
    }

    public void Item1()
    {
        TilePlacingSystem.list = 1;
        Close();
    }

    public void Item2()
    {
        TilePlacingSystem.list = 2;
        Close();
    }

    public void Item3()
    {
        TilePlacingSystem.list = 3;
        Close();
    }
}
