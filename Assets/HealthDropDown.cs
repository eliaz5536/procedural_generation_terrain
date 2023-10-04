using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropDown : MonoBehaviour
{
    // healthbar
    public GameObject healthbar_bg;
    public GameObject healthbar_fill;

    // heart
    public GameObject heart_fill;
    public GameObject heart_bg;

    // plus
    public GameObject plus_fill;
    public GameObject plus_bg;

    public void healthDropDownList(int val)
    {
        if(val == 0)
        {
            healthbar_bg.SetActive(true);
            healthbar_fill.SetActive(true);

            heart_fill.SetActive(false);
            heart_bg.SetActive(false);

            plus_fill.SetActive(false);
            plus_bg.SetActive(false);
        }
        if(val == 1)
        {
            healthbar_bg.SetActive(false);
            healthbar_fill.SetActive(false);

            heart_fill.SetActive(true);
            heart_bg.SetActive(true);

            plus_fill.SetActive(false);
            plus_bg.SetActive(false);
        }
        if(val == 2)
        {
            healthbar_bg.SetActive(false);
            healthbar_fill.SetActive(false);

            heart_fill.SetActive(false);
            heart_bg.SetActive(false);

            plus_fill.SetActive(true);
            plus_bg.SetActive(true);
        }
    }
}
