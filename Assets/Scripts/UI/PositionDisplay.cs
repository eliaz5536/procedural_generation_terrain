using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PositionDisplay : MonoBehaviour
{
    [Header("Player Model")]
    public Rigidbody FirstPersonController;

    [Header("Position")]
    public TextMeshProUGUI PosX;
    public TextMeshProUGUI PosY;
    public TextMeshProUGUI PosZ;

    [Header("Rotation")]
    public TextMeshProUGUI RotX;
    public TextMeshProUGUI RotY;
    public TextMeshProUGUI RotZ;

    void Update()
    {
        // Positions
        float positionX = FirstPersonController.position.x;
        float positionY = FirstPersonController.position.y;
        float positionZ = FirstPersonController.position.z;
        PosX.text = "Position X: " + positionX.ToString();
        PosY.text = "Position Y: " + positionY.ToString();
        PosZ.text = "Position Z: " + positionZ.ToString();

        // Rotation
        float rotationX = FirstPersonController.rotation.x;
        float rotationY = FirstPersonController.rotation.y;
        float rotationZ = FirstPersonController.rotation.z;
        RotX.text = "Rotation X: " + rotationX.ToString();
        RotY.text = "Rotation Y: " + rotationY.ToString();
        RotZ.text = "Rotation Z: " + rotationZ.ToString();
    }
}
