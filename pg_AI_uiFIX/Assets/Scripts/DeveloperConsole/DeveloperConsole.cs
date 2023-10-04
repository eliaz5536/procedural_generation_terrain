using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Console
{

    // IMPORTANT:
    /*
     * - Figure out why you can't perform a simple toggle switch with this 'Developer Console'
     *   than if you were to use a previous Debug Controller.
     * - Try to figure that out for yourself
     * 
     * - If you can't focus on this part, focus on spawning those Trees on the ground with existing examples
     *   just so that you can even get started and create something very cool that would help you advance
     *   developing this game, to focus on utilizing Artificial Intelligence
     * 
     */

    public abstract class ConsoleCommand
    {
        public abstract string Name { get; protected set; }
        public abstract string Command { get; protected set; }
        public abstract string Description { get; protected set; }
        public abstract string Help { get; protected set; }

        public void AddCommandToConsole()
        {
            
        }

        public abstract void RunCommand();
    }

    public class DeveloperConsole : MonoBehaviour
    {
        public static DeveloperConsole Instance { get; private set; }
        public static Dictionary<string, ConsoleCommand> Commands { get; private set; }

        [Header("GameObjects")]
        public GameObject console;
        public GameObject mainCanvas;
        public GameObject inventory;
        public bool consoleDisabled;
        public bool mainCanvasDisabled;

        [Header("UI Console Components")]
        public Canvas consoleCanvas;
        public ScrollRect scrollRect;
        public Text consoleText;
        public Text inputText;
        public InputField consoleInput;

        private void Awake()
        {
            if(Instance != null)
            {
                return;
            }

            Instance = this;
            Commands = new Dictionary<string, ConsoleCommand>();
        }

        private void Start()
        {
            exitConsole();

            consoleDisabled = true;
            mainCanvasDisabled = false;
        }

        private void CreateCommands()
        {
            
        }

        public static void AddCommandsToConsole(string _name, ConsoleCommand _command)
        {
            if(!Commands.ContainsKey(_name))
            {
                Commands.Add(_name, _command);
            }
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                if(consoleDisabled == true)
                {
                    exitConsole();
                }
                else
                {
                    showConsole();
                }
            }
        }

        private void showConsole()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // consoleCanvas.gameObject.SetActive(true);
            console.SetActive(true);
            mainCanvas.SetActive(false);

            Time.timeScale = 0f;

            Debug.Log("CONSOLE -- Enabled");


            consoleDisabled = false;
            mainCanvasDisabled = true;
        }

        private void exitConsole()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            // consoleCanvas.gameObject.SetActive(false);
            console.SetActive(false);
            mainCanvas.SetActive(true);

            Time.timeScale = 1f;

            Debug.Log("CONSOLE -- Disabled");

            consoleDisabled = true;
            mainCanvasDisabled = false;
        }

    }
}
