using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GL_MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject optionsMenu;

    [SerializeField]
    private GameObject cursorCanvas;
    private bool menuIsActive = false;
    private bool optionsMenuOpen = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetMenuState();
        }
    }

    private void SetMenuState()
    {
        if (menuIsActive)
        {
            CloseMenu();
            return;
        }
        OpenMenu();
    }



    private void OpenMenu()
    {
        menuIsActive = true;
        Cursor.visible = false;
        ui.SetActive(true);
        mainMenu.SetActive(true);
        cursorCanvas.SetActive(true);
    }



    public void CloseMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(false);
        ui.SetActive(false);
        cursorCanvas.SetActive(false);
        menuIsActive = false;
    }



    //connect to back and options button
    public void ChangeMenu()
    {
        if (optionsMenuOpen == false)
        {
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            optionsMenuOpen = true;
            return;
        }
        else
        {
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            optionsMenuOpen = false;
            return;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
