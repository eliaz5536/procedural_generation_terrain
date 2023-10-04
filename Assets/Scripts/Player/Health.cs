using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Healthbar_script healthbar_Script;
    public float health = 100f;

    public void takeDamage(float damageAmount)
    {
        health = (healthbar_Script.CurrentHealth - damageAmount) / healthbar_Script.MaxHealth;
        healthbar_Script.CurrentHealth -= damageAmount;
        healthbar_Script.CurrentHealth = Mathf.Round(healthbar_Script.CurrentHealth);

        // Debug.Log("Current health: " + healthbar_Script.CurrentHealth);
        Debug.Log("CURRENT HEALTH: " + health);

        if(health <= 0f)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        // Initialize this scene over this method here!
        Debug.LogError("GAME OVER!");
    }
}
