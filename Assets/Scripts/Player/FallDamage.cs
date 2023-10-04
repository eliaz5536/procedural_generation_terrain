using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    public Health healthbar;
    // public Transform 
    // public Rigidbody Player;
    public float startYPos;
    public float endYPos;
    public float damageThreshold = 10;
    public bool damageMe = false;
    public bool firstCall = true;

    void Update()

    {
       if(!GameObject.FindObjectOfType<CharacterController>().isGrounded)
        {
            if(gameObject.transform.position.y > startYPos)
            {
                firstCall = true;
            }
            if(firstCall)
            {
                startYPos = gameObject.transform.position.y;
                firstCall = false;
                damageMe = true;
            }
        }

        if(GameObject.FindObjectOfType<CharacterController>().isGrounded)
        {
            endYPos = gameObject.transform.position.y;
            if(startYPos - endYPos > damageThreshold)
            {
                if(damageMe)
                {
                    healthbar.GetComponent<Health>().takeDamage(startYPos - endYPos - damageThreshold);
                    damageMe = false;
                    firstCall = true;
                }
            }
        }
    }
}
