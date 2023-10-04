using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	// (IMPORTANT!!)
	// youtube.com/watch?v=xppompv1DBg
	// Even with the new Enemy added (Thanks to Brackeys)
	// 	--> I still do not understand why the enemy does not stand on the ground. Why?
	// 	WHY???
	//
	// 	--> It peforms the same ability as the enemy.
	// 		--> Now you need to add stats for the enemy to show health and attack	
	// 		--> youtube.com/watch?v=UjkSFoLxesw
	// 		--> You can create those health and attack stats here
	// 			--> Apply the same with other NPCs
	//
	
	public float lookRadius = 10f;
	public float moveSpeed = 5f;

	public float rotSpeed = 100f;
		
	public float health = 40f;
	public float attackDamage = 10f;

	bool isWandering = false;
	bool isRotatingLeft = false;
	bool isRotatingRight = false;
	bool isWalking = false;

	public Transform target;
	NavMeshAgent agent;

	public Rigidbody rb;

        void Start()
        {
            // target = PlayerManager.instance.player.transform;	
            agent = GetComponent<NavMeshAgent>(); 

            // Added new line
            // rb = GetComponent<Rigidbody>();

            // New line
            // setting Enemy's isKinematic to false;
            // rb.isKinematic = false;
        }

        void Update()
        {
       		float distance = Vector3.Distance(target.position, transform.position);

            // Reset the Position Y for the enemy when the enemy does not see the target.
			/*
            float rotx = 0;
			float roty = 90;
			float rotz = 0;
			transform.Rotate(rotx, roty, rotz);
			transform.Rotate(transform.rotation.y * Time.deltaTime * rotSpeed);
			*/

            if (isWandering == false)
            {
                StartCoroutine(Wander());
            }
            if (isRotatingRight == true)
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

			if (distance <= lookRadius) {
       			rb.transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

				transform.LookAt(target);
                agent.SetDestination(target.position);

                if(distance <= agent.stoppingDistance) {
                    
                    // Attack the target 
                    FaceTarget();
                }
            }

        }

	void FaceTarget() {
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;	
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}

	void takeDamage(float damage) 
	{
		health -= damage;

		if(health <= 0) {
			Invoke(nameof(DestroyEnemy), 0.5f);
		}
	}

	void DestroyEnemy() 
	{
		Destroy(gameObject);
	}

	// Wander animations
	IEnumerator Wander()
	{
		int rotTime = Random.Range(1, 3);
		int rotateWait = Random.Range(1, 4);
		int rotateLorR = Random.Range(1, 2);
		int walkWait = Random.Range(1, 4);
		int walkTime = Random.Range(1, 5);

		isWandering = true;

		yield return new WaitForSeconds(walkWait);
		isWalking = true;
		yield return new WaitForSeconds(walkTime);
		isWalking = false;
		yield return new WaitForSeconds(rotateWait);
		if (rotateLorR == 1)
		{
			isRotatingRight = true;
			yield return new WaitForSeconds(walkTime);
			isRotatingRight = false;
		}
		if (rotateLorR == 2)
		{
			isRotatingLeft = true;
			yield return new WaitForSeconds(walkTime);
			isRotatingLeft = false;
		}
		isWandering = false;
	}

}
