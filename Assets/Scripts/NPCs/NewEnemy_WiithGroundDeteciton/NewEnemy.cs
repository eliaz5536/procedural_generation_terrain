using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
	public Rigidbody newEnemyPlayer;

	public float Distance;
	public bool isAngered;
	// public NavMeshAgent _agent;
	
	public float moveSpeed = 3f;
	public float rotSpeed = 100f;

	private bool isWandering = false;
	private bool isRotatingLeft = false;
	private bool isRotatingRight = false;
	private bool isWalking = false;

	public float gravity = -9.81f;
	public bool isGrounded;
	
        void Update()
    	{
   		float x = Input.GetAxis("Horizontal");
   		float z = Input.GetAxis("Vertical");
    	}

}
