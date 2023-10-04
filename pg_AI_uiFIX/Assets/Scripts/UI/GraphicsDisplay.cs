using System.Collections;
using TMPro;
using UnityEngine;

public class GraphicsDisplay : MonoBehaviour
{
    public TextMeshProUGUI SystemInfoProcessorCount;
    public TextMeshProUGUI SystemInfoProcessorFrequency;
    public TextMeshProUGUI SystemInfoProcessorType;
    public TextMeshProUGUI SystemInfoGraphicsMemorySize;
    public TextMeshProUGUI SystemInfoSystemMemorySize;
    public TextMeshProUGUI SystemInfoGraphicsDeviceName;
    public TextMeshProUGUI SystemInfoOperatingSystem;
    public TextMeshProUGUI SystemInfoOperatingSystemFamily;

    void Update()
    {
        SystemInfoProcessorCount.text = "Processor Count: " + SystemInfo.processorCount.ToString();
        SystemInfoProcessorFrequency.text = "Processor Frequency: " + SystemInfo.processorFrequency.ToString();
        SystemInfoProcessorType.text = "Processor Type: " + SystemInfo.processorType.ToString();
        SystemInfoGraphicsMemorySize.text = "Graphic Memory Size: " + SystemInfo.graphicsMemorySize.ToString();
        SystemInfoGraphicsDeviceName.text = "Graphic Device Name: " + SystemInfo.graphicsDeviceName.ToString();
        SystemInfoOperatingSystem.text = "OS: " + SystemInfo.operatingSystem.ToString();
        SystemInfoOperatingSystemFamily.text = "OS Family: " + SystemInfo.operatingSystemFamily.ToString();
        SystemInfoSystemMemorySize.text = "System Memory Size: " + SystemInfo.systemMemorySize.ToString();
    }
}
