using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI FpsText;

    // private float pollingTime = 1f;
    private float pollingTime = 0.1f;
    private float time;
    private int frameCount;

    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = frameRate.ToString() + " FPS";

            if(frameRate >= 30)
            {
                FpsText.color = new Color32(68, 214, 44, 255);
            }
            else if(frameRate >= 20 && frameRate < 30)
            {
                FpsText.color = new Color32(255, 211, 0, 255);
            }
            else if(frameRate < 20)
            {
                FpsText.color = new Color32(255, 0, 0, 255);
            }

            time -= pollingTime;
            frameCount = 0;

        }
    }
}
