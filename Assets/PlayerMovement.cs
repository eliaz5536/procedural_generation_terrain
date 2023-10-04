using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float fallThresholdVelocity = 1.7f;

    // Variables to calculate the air time that takes away player's health when hitting the ground.
    public float minSurviveFall = 2f;
    public float damageForSeconds = 1f;
    public float airTime = 0f;
    public float damage;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    bool wasGrounded;

    bool wasFalling;

    private float startOfFall;
    public float minimumFall = 5f;

    public AudioSource ground_hit;

    public Health playerHealth;
    public Healthbar_script healthbar_Script;

    public Vector3 Velocity
    {
        get { return controller.velocity; }
    }

    public bool Falling
    {
        get { return (!isGrounded && controller.velocity.y < 0); }
    }

    void Update()
    {
        // Default Min Move Distance: 0.001
        // New min Move Distance: 0

        // Default Skin Width: 0.08
        // New Skin Width: 0

        Debug.Log("Current player health: " + playerHealth.health);

        bool previouslyGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = 2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Jump");
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // if(!wasFalling && Falling)
        if(Falling)
        {
            // Don't delete that line.
            // startOfFall = transform.position.y;

            airTime += Time.deltaTime;
            Debug.Log("airTime: " + airTime);
        }

        if(!wasGrounded && isGrounded)
        {
            /*
            float fallDistance = startOfFall - transform.position.y;

            if(fallDistance > minimumFall)
            {
                ground_hit.Play();
                Debug.Log("Player fell " + (startOfFall - transform.position.y) + " units");
            }
            */

            Debug.Log("HIT GROUND!");

            if (airTime > minSurviveFall)
            {
                damage -= damageForSeconds * airTime;
                ground_hit.Play();
                Debug.Log("Damage dealt: " + damage);

                // playerHealth.health = -damage;
                playerHealth.takeDamage(damage);

                Debug.Log("CURRENT HEALTH (PLAYER): " + playerHealth.health);
            }

            airTime = 0;
        }

        wasGrounded = isGrounded;
        wasFalling = Falling;
        
        // Physics based approached to falling that does not seem to work with Character Controller.
        /*
        if(!previouslyGrounded && isGrounded)
        {
            // Fall Damage
            Debug.Log("Controller velocity y: " + velocity.y);
            Debug.Log("Do Damage: " + (velocity.y < -fallThresholdVelocity));

            if(velocity.y < -fallThresholdVelocity)
            {
                float damage = Mathf.Abs(velocity.y + fallThresholdVelocity);
                Debug.Log("Damage dealth: " + damage);
            }
        }
        */

        /*
        // Keep that code!
        // Time-based physics approach to fall damage
        if(!isGrounded)
        {
            airTime += Time.deltaTime;
            Debug.Log("airTime: " + airTime);

            if(isGrounded)
            {
                if (airTime > minSurviveFall)
                {
                    damage -= damageForSeconds * airTime;
                    ground_hit.Play();
                    Debug.Log("Damage dealt: " + damage);
                }
                else
                {
                    Debug.Log("You're safe boi");
                }
                airTime = 0;
            }
        }
        */

    }
}
