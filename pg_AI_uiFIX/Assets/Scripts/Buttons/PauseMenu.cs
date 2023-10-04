using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public bool isPaused;
    public GameObject quitConfirmation;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void SettingsMenu() {
        pauseMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        settingsMenu.SetActive(true);
    }

    void showPopUp()
    {
        quitConfirmation.gameObject.SetActive(true);
    }

    void hidePopUp()
    {
        quitConfirmation.gameObject.SetActive(false);
    }

    void mainMenu()
    {
        SceneManager.LoadScene("Multiplayer");
    }

    void quitGame()
    {
        Application.Quit();
    }
}
