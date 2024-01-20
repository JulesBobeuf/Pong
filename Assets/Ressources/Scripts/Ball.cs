using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float movementSpeed;

	public float extraSpeedPerHit;

	public float maxSpeed;

	int hitCounter = 0;

	public void Start()
	{
		StartCoroutine(this.StartBall());
	}

	public void positionBall(bool isStartingPlayer1)
	{
		this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
		if (isStartingPlayer1)
		{
			this.gameObject.transform.localPosition = new Vector3(-50, 0, 0);
		}
		else
		{
            this.gameObject.transform.localPosition = new Vector3(50, 0, 0);
        }
	}
	public IEnumerator StartBall(bool isStartingPlayer1 = true)
	{
		this.positionBall(isStartingPlayer1);


        this.hitCounter = 0;
		yield return new WaitForSeconds(1);
		if (isStartingPlayer1)
		{
			this.MoveBall(new Vector2(-1, 0));
		}
		else
		{
			this.MoveBall(new Vector2(1,0));
		}

	}
	public void MoveBall(Vector2 direction)
	{
		direction = direction.normalized;
		float speed = this.movementSpeed + (extraSpeedPerHit * hitCounter);
		Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
		rb.velocity = direction * speed;

	}
	
	public void increaseHitCounter()
	{
		if (movementSpeed + (this.hitCounter * this.extraSpeedPerHit) <= maxSpeed)
		{
			this.hitCounter++;
		}
	}
}
