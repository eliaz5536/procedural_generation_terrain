using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassiveController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float rotSpeed = 100f;

	public float health = 40f;

	bool isWandering = false;
	bool isRotatingLeft = false;
	bool isRotatingRight = false;
	bool isWalking = false;

	public Rigidbody rb;

	void Update()
	{
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
	}

	void takeDamage(float damage)
	{
		health -= damage;

		if (health <= 0)
		{
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
