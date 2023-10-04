using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OffsetDisplay : MonoBehaviour
{
    public MapGenerator mapGenerator;
    public TextMeshProUGUI offsetX;
    public TextMeshProUGUI offsetY;

    void Update()
    {
        float OffsetX = mapGenerator.offset.x;
        float OffsetY = mapGenerator.offset.y;

        offsetX.text = "Offset X: " + OffsetX.ToString();
        offsetY.text = "Offset Y: " + OffsetY.ToString();
    }
}
