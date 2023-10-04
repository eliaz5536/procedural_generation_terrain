using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public Text FPSText;

    private float pollingTime = 0.05f;
    private float time;
    private int frameCount;

    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FPSText.text = frameRate.ToString() + " FPS";

            if(frameRate >= 30)
            {
                FPSText.color = new Color32(68, 214, 44, 255);
            }
            else if(frameRate >= 20 && frameRate < 30)
            {
                FPSText.color = new Color32(255, 211, 0, 255);
            }
            else if(frameRate < 20)
            {
                FPSText.color = new Color32(255, 0, 0, 255);
            }

            time -= pollingTime;
            frameCount = 0;

        }
    }
}
