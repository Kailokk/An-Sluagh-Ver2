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
    private bool menuIsActive = false;
    private bool optionsMenuOpen = false;

    [SerializeField]
    private GameObject Cursor;

    [SerializeField]
    private Camera mainCamera;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SetMenuState();
        }

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Cursor.transform.position = mousePos;

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
        ui.SetActive(true);
        mainMenu.SetActive(true);
    }



    private void CloseMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(false);
        ui.SetActive(false);
    }



    //connect to back and options button
    private void ChangeMenu()
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


}
