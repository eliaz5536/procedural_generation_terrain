using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar_script : MonoBehaviour
{
    public Image HealthBar;
    public Image PlusImage;
    public Image Heart;

    public Text healthText;

    public float CurrentHealth;
    public float MaxHealth = 100f;
    Health Player;

    // dropdown
    // public Dropdown healthDropdown;

    void Start()
    {
        HealthBar = GetComponent<Image>();
        PlusImage = GetComponent<Image>();
        Heart = GetComponent<Image>();
        Player = FindObjectOfType<Health>();

        // healthText = GetComponent<Text>();
        // healthDropdown = GetComponent<Dropdown>();
    }

    void Update()
    {
        // CurrentHealth = Player.health;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;

        // healthText.text = CurrentHealth.ToString();
    }
}
