using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour
{
    public bool consoleDisabled;
    public bool mainCanvasDisabled;

    string input;

    public GameObject console;
    public GameObject mainCanvas;
    public GameObject inventory;
    public GameObject pauseMenu;

    void Start()
    {
        consoleDisabled = true;
        mainCanvasDisabled = false;

        exitConsole(); 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(consoleDisabled == true)
            {
                exitConsole();
                consoleDisabled = false;
                mainCanvasDisabled = true;
            }
            else
            {
                showConsole();
                consoleDisabled = true;
                mainCanvasDisabled = false;
            }
        }
    }

    private void showConsole()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        console.SetActive(true);
        mainCanvas.SetActive(false);
        inventory.SetActive(false);
        pauseMenu.SetActive(false);

        Time.timeScale = 0f;

        Debug.Log("CONSOLE ENABLED!");
    }

    private void exitConsole()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        console.SetActive(false);
        mainCanvas.SetActive(true);
        inventory.SetActive(true);
        pauseMenu.SetActive(false);

        Time.timeScale = 1f;
        
        Debug.Log("CONSOLE DISABLED");
    }
}
