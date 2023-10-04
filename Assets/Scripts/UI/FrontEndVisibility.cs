using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontEndVisibility : MonoBehaviour
{
    public GameObject FrontEnd;
    public GameObject Inventory;

    void Update()
    {
        // Main-Menu
        if(Input.GetKeyDown(KeyCode.L))
        {
            FrontEnd.SetActive(false);
            Debug.Log("FrontEnd = DISABLED");
        }
        if(Input.GetKeyUp(KeyCode.L))
        {
            FrontEnd.SetActive(true);
            Debug.Log("FrontEnd = ENABLED");
        }

        // Inventory
        if(Input.GetKeyUp(KeyCode.I))
        {
            Inventory.SetActive(true); 
            FrontEnd.SetActive(false);
            Debug.Log("Inventory = DISABLED");
        }
        if(Input.GetKeyUp(KeyCode.I)) 
        {
            Inventory.SetActive(true); 
            FrontEnd.SetActive(false);
            Debug.Log("Inventory = DISABLED");
        }

    }
}
