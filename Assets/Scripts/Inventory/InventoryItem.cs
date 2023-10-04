using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Item itemData;
    public Text amountText;

    public int amount = 1;

    private void Update()
    {
        if(amount <= 1)
        {
            amountText.gameObject.SetActive(false);
        }
        else
        {
            amountText.gameObject.SetActive(true);
        }
        amountText.text = amount.ToString();
    }
}
