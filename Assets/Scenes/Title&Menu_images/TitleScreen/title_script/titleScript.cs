using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class titleScript : MonoBehaviour
{
    public Canvas canvas;
    public Canvas menuCanvas;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if(Input.anyKey) {
            canvas.gameObject.SetActive(false);
            menuCanvas.gameObject.SetActive(true);
        }
    }
}
