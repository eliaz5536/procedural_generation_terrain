using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Master : MonoBehaviour
{
    public CapsuleCollider Capsule;
    public GameObject Player;

    public Rigidbody EnemyPlayer;

    public float Distance;
    public bool isAngered;
    public NavMeshAgent _agent;

    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask ground;
    public bool previouslyGrounded;
    public Vector3 groundContactNormal;

    Vector3 velocity;
    public float gravity = -9.81f;
    public bool isGrounded;

    void Update()
    {

        Distance = Vector3.Distance(Player.transform.position, this.transform.position);

        if(Distance <= 5)
        {
            isAngered = true;
        }

        if(Distance > 5f)
        {
            isAngered = false;
        }

        if(isAngered)
        {
             _agent.isStopped = false;
            _agent.SetDestination(Player.transform.position);
        }

        if(!isAngered)
        {
            _agent.isStopped = true;
        }

        if (isWandering == false)
       {
           StartCoroutine(Wander());
       }
       if(isRotatingRight == true)
       {
           transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
       }
       if (isRotatingLeft == true)
       {
           transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
       }
       if (isWalking == true)
       {
           transform.position += transform.forward * moveSpeed * Time.deltaTime;
       }

	GroundCheck();
    }

    IEnumerator Wander()
   {
       int rotTime = Random.Range(1,3);
       int rotateWait = Random.Range(1,4);
       int rotateLorR = Random.Range(1,2);
       int walkWait = Random.Range(1,4);
       int walkTime = Random.Range(1,5);

       isWandering = true;

       yield return new WaitForSeconds(walkWait);
       isWalking = true;
       yield return new WaitForSeconds(walkTime);
       isWalking = false;
       yield return new WaitForSeconds(rotateWait);
       if(rotateLorR == 1)
       {
           isRotatingRight = true;
           yield return new WaitForSeconds(walkTime);
           isRotatingRight = false;
       }
       if(rotateLorR == 2)
       {
           isRotatingLeft = true;
           yield return new WaitForSeconds(walkTime);
           isRotatingLeft = false;
       }
       isWandering = false;
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        EnemyPlayer.MovePosition(velocity * Time.deltaTime); 
    }

    private void GroundCheck()
    {
	// EnemyPlayer.velocity.y += gravity * Time.deltaTime;
	velocity.y += gravity * Time.deltaTime;

	if(!isGrounded) {
		EnemyPlayer.AddRelativeForce(Vector3.down * gravity);
		Debug.Log("The enemy is currently in the air!");
	}
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

}
