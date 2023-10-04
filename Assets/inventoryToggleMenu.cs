using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryToggleMenu : MonoBehaviour
{
    public GameObject mainCanvas;

    public GameObject inventoryBackground;
    public GameObject SlotHolder;
    public GameObject HotbarSlotHolder;

    public CharacterController firstPerson;

    public bool inventoryIsClosed;
    public bool mainCanvasDisabled;

    void Start()
    {
        inventoryIsClosed = false;
        mainCanvasDisabled = false;

        exitInventory();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            if(inventoryIsClosed == true)
            {
                inventoryMenu();
                inventoryIsClosed = false;
                mainCanvasDisabled = false;
            }
            else
            {
                exitInventory();
                inventoryIsClosed = true;
                mainCanvasDisabled = true;
            }
        }
    }

    void inventoryMenu()
    {
        // inventory.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        firstPerson.GetComponentInChildren<MouseLook>().enabled = false;

        inventoryBackground.SetActive(true);

        SlotHolder.SetActive(true);

        // Change anchor posiions, including with Position X & Y as its default state
        HotbarSlotHolder.SetActive(true);
        // HotbarSlotHolder.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        HotbarSlotHolder.GetComponent<RectTransform>().anchoredPosition = new Vector2(-829.6301f, -264f);

        mainCanvas.SetActive(false);
    }

    void exitInventory()
    {
        // inventory.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        firstPerson.GetComponentInChildren<MouseLook>().enabled = true;

        inventoryBackground.SetActive(false);

        SlotHolder.SetActive(false);

        // Change anchor posiions, including with Position X & Y
        HotbarSlotHolder.SetActive(true);
        HotbarSlotHolder.GetComponent<RectTransform>().anchoredPosition = new Vector2(20f, -800f);

        mainCanvas.SetActive(true);
    }
}
