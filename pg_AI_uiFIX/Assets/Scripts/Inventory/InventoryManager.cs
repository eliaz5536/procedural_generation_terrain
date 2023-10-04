using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // IMPORTANT: Go back to 38:40 video count to manage inventory
    // THIS IS TO CREATE SLOT PREFAB
    // https://www.youtube.com/watch?v=9_z6aam-Qt0

    public GameObject inventory;

    public Transform inventorySlotHolder;
    public Transform inventoryHotbarSlotHolder;

    public Transform cursor;
    public Vector3 offset;

    public List<bool> isFull;
    public List<Transform> slots;
    public List<Transform> hotbarSlots;

    public int currentSlot;

    private void Start()
    {
        initializeInventory();
        SetSlotIDS();
        CheckSlots();
    }

    private void Update()
    {
        if(inventory.activeSelf == true)
        {
            cursor.position = Input.mousePosition + offset;
        }

        if (cursor.childCount > 0)
        {
            cursor.gameObject.SetActive(true);
        }
        else
        {
            cursor.gameObject.SetActive(false);
        }
    }

    void initializeInventory()
    {
        // Sets Slots
        for(int i = 0; i < inventorySlotHolder.childCount; i++)
        {
            slots.Add(inventorySlotHolder.GetChild(i));
            isFull.Add(false);
        }

        for(int i = 0; i < inventoryHotbarSlotHolder.childCount; i++)
        {
            slots.Add(inventoryHotbarSlotHolder.GetChild(i));
            hotbarSlots.Add(inventoryHotbarSlotHolder.GetChild(i));
            isFull.Add(false);
        }
    }

    void SetSlotIDS()
    {
        for(int i = 0; i < slots.Count; i++)
        {
            if(slots[i].GetComponent<Slot>() != null)
            {
                slots[i].GetComponent<Slot>().ID = i;
            }
        }
    }

    void CheckSlots()
    {
        // Checks if Slots are full!
        for(int i = 0; i < slots.Count; i++)
        {
           if(slots[i].childCount > 0)
           {
                isFull[i] = true;
           }
           else
           {
                isFull[i] = false;
           }
        }
    }

    void AddItem(GameObject item, int amount)
    {
        for(int i = 0; i < amount; i++)
        {

            for(int x = 0; x < slots.Count; x++)
            {
                if(isFull[x] == false)
                {
                    // Add the item
                    Instantiate(item, slots[x]);
                    CheckSlots();
                    return;
                }
                else
                {
                    Debug.Log("Slot is full");
                }
            }
        }
        Debug.Log("All slots are full");
    }

    public void PickupDropInventory()
    {
        if(slots[currentSlot].childCount > 0 && cursor.childCount < 1)
        {
            // Put inside cursor
            Instantiate(slots[currentSlot].GetChild(0).gameObject, cursor);
            Destroy(slots[currentSlot].GetChild(0).gameObject);
        }
        else if(slots[currentSlot].childCount < 1 && cursor.childCount > 0)
        {
            // Put Inside Slot
            Instantiate(cursor.GetChild(0).gameObject, slots[currentSlot]);
            Destroy(cursor.GetChild(0).gameObject);
        }
        else if(slots[currentSlot].childCount > 0 && cursor.childCount > 0)
        {
            if(slots[currentSlot].GetChild(0).GetComponent<InventoryItem>().itemData.ID == cursor.GetChild(0).GetComponent<InventoryItem>().itemData.ID)
            {
                if(slots[currentSlot].GetChild(0).GetComponent<InventoryItem>().amount <= cursor.GetChild(0).GetComponent<InventoryItem>().itemData.maxStack - slots[currentSlot].GetChild(0).GetComponent<InventoryItem>().amount)
                {
                    slots[currentSlot].GetChild(0).GetComponent<InventoryItem>().amount += cursor.GetChild(0).GetComponent<InventoryItem>().amount;
                    Destroy(cursor.GetChild(0).gameObject);
                }
            }
        }
        CheckSlots();
    }
}
