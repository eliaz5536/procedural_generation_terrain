using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    // TASK: Create an inventory system that can be used to pickup
    // or drop certain items that is worth for the player
    // This can be by which, can store food, items, weapons and more
    // Create your inventory system in the style of Rust

    // ESSENTIAL: Watch the followig tutorials to create a draggable and dropable item
    // https://www.youtube.com/watch?v=Cf-3SPL1IMI --> Continue from 10:54 / 48:57
    // https://www.youtube.com/watch?v=lUIZRHvpXhA
    // https://www.youtube.com/watch?v=stm7DakcxG8

    // ESSENTIAL: YouTube video for you to understand Rust's inventory rigging system
    // https://www.youtube.com/watch?v=9_z6aam-Qt0

    // Another video about YouTube inventory system
    // https://www.youtube.com/watch?v=2ajD1GDbEzA

    public GameObject mainCanvas;
    public GameObject inventory;
    public bool inventoryEnabled;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    // public GameObject slotHolder;


    void Start()
    {
        /*
        allSlots = 40;
        slot = new GameObject[allSlots];

        for(int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        */
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
            Debug.Log("Inventory should be opened... by pressing I");
        }

        if(inventoryEnabled == true)
        {
            inventory.SetActive(true);
            mainCanvas.SetActive(false);
        }
        else
        {
            inventory.SetActive(false);
            mainCanvas.SetActive(true);
        }

    }
}
