using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class changeHUDPosition : MonoBehaviour
{
    // Resolution[] resolution;

    [Header("Health")]
    public Image healthBar;
    public Image healthBar_fill;
    public Image heart;
    public Image heart_fill;
    public Image plus;
    public Image plus_fill;
    public Slider xHealthbar_slider;
    public Slider yHealthbar_slider;
    public Slider healthBar_scale;
    public float xHealthbar;
    public float yHealthbar;
    public float scaleHealthbar;

    [Header("Minimap")]
    public GameObject miniMap;
    public Slider xMinimap_slider;
    public Slider yMinimap_slider;
    public Slider miniMap_scale;
    public float xMinimap;
    public float yMinimap;
    public float scaleMinimap;

    [Header("Player Health")]
    public Text playerHealth;
    public Slider xPlayerHealth_slider;
    public Slider yPlayerHealth_slider;
    public Slider playerHealth_scale;
    public float xPlayerHealth;
    public float yPlayerHealth;
    public float scalePlayerHealth;

    [Header("Day")]
    public TextMeshProUGUI dayCount;
    public Slider xDay_slider;
    public Slider yDay_slider;
    public Slider dayCount_scale;
    public float xDay;
    public float yDay;
    public float scaleDay;

    [Header("Time")]
    public TextMeshProUGUI time;
    public Slider xTime_slider;
    public Slider yTime_slider;
    public Slider time_scale;
    public float xTime;
    public float yTime;
    public float scaleTime;

    [Header("Normal Variables")]
    public float x;
    public float y;

    void Update()
    {
        changeHealthPos();
        changeMinimapPos();
        changeHealthTextPos();
        changeDayPos();
        changeTimePos();

        Debug.LogWarning("Screen Width: " + Screen.width);
        Debug.LogWarning("Screen Height: " + Screen.height);
    }

    /*
     *  IMPORTANT:
     *  =========
     *  
     *  Now your goal is the optimize the hell out of those functions once they do exactly as they function 
     *  This is even fixing one of those sliders that can only to the right (X-Axis) and the fact that is it 
     *  fixed onto an anchor point.
     *  
     */

    // ANOTHER IMPORTANT NOTE:
    /*
     * Think of how you can print debugging logs to detect the screen resolution and place UI elements from 0 
     * (meaning from the beginning which is 0, to `1080p, which is the end.).
     * Same principle applies over with the hight, 0 being the ground and 1920 being the top).
     * Very creative idea for user customization!
     * 
     * Watch YouTube videos about ScreenToWorldPosition and how can that be translated into your work!
     * *insert link down below*
     * 
     * Even this one 
     * https://www.youtube.com/results?search_query=unity+slider+to+screen+width+and+height
     */

    void changeHealthPos()
    {
        // HEALTHBAR
        xHealthbar = xHealthbar_slider.value;
        xHealthbar_slider.maxValue = Screen.width;
        yHealthbar = yHealthbar_slider.value;
        yHealthbar_slider.maxValue = Screen.height;

        scaleHealthbar = healthBar_scale.value;

        // HEALTHBAR - Transformation Position
        healthBar.transform.position = new Vector2(transform.position.x + xHealthbar, transform.position.y + yHealthbar);
        healthBar_fill.transform.position = new Vector2(transform.position.x + xHealthbar, transform.position.y + yHealthbar);

        // HEART - Transformation Position
        heart.transform.position = new Vector2(transform.position.x + xHealthbar, transform.position.y + yHealthbar);
        heart_fill.transform.position = new Vector2(transform.position.x + xHealthbar, transform.position.y + yHealthbar);

        // PLUS - Transformation Position
        plus.transform.position = new Vector2(transform.position.x + xHealthbar, transform.position.y + yHealthbar);
        plus_fill.transform.position = new Vector2(transform.position.x + xHealthbar, transform.position.y + yHealthbar);

        // HEALTHBAR SCALE
        healthBar.transform.localScale = new Vector2(scaleHealthbar, scaleHealthbar);
        healthBar_fill.transform.localScale = new Vector2(scaleHealthbar, scaleHealthbar);
        heart.transform.localScale = new Vector2(scaleHealthbar, scaleHealthbar);
        plus.transform.localScale = new Vector2(scaleHealthbar, scaleHealthbar);

    }

    void changeMinimapPos()
    {
        //! COMPLETE THIS METHOD 
        //! IMPORT MINIMAP
        xMinimap = xMinimap_slider.value;
        xMinimap_slider.maxValue = Screen.width;
        yMinimap = yMinimap_slider.value;
        yMinimap_slider.maxValue = Screen.height;

        scaleMinimap = miniMap_scale.value;

        miniMap.transform.position = new Vector2(transform.position.x + xMinimap, transform.position.y + yMinimap);
    
        // Think how you can scale the minimap
        // miniMap.transform.localScale = new Vector2(miniMap.);
    }

    void changeHealthTextPos()
    {
        xPlayerHealth = xPlayerHealth_slider.value;
        xPlayerHealth_slider.maxValue = Screen.width;

        // PlayHeahlth text Y-Axis does not seem to function, why?
        // Look back at that function
        yPlayerHealth = yPlayerHealth_slider.value;
        yPlayerHealth_slider.maxValue = Screen.height;

        scalePlayerHealth = playerHealth_scale.value; 

        playerHealth.transform.position = new Vector2(transform.position.x + xPlayerHealth, transform.position.y + yPlayerHealth);

        playerHealth.transform.localScale = new Vector2(scalePlayerHealth, scalePlayerHealth);
    }

    void changeDayPos()
    {
        xDay = xDay_slider.value;
        xDay_slider.maxValue = Screen.width;
        yDay = yDay_slider.value;
        yDay_slider.maxValue = Screen.height;

        scaleDay = dayCount_scale.value;

        dayCount.transform.position = new Vector2(transform.position.x + xDay, transform.position.y + yDay);

        dayCount.transform.localScale = new Vector2(scaleDay, scaleDay);
    }

    void changeTimePos() 
    { 
        xTime = xTime_slider.value;
        xTime_slider.maxValue = Screen.width;
        yTime = yTime_slider.value;
        yTime_slider.maxValue = Screen.height;

        scaleTime = time_scale.value;

        time.transform.position = new Vector2(transform.position.x + xTime, transform.position.y + yTime);

        time.transform.localScale = new Vector2(scaleTime, scaleTime);
    }
}
