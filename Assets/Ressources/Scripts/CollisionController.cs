using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	public Ball ball;

	public ScoreController scoreController;

	void BounceFromRacket(Collision2D c)
	{
		Vector3 ballPosition = this.transform.position;
		Vector3 racketPosition = c.gameObject.transform.position;

		float racketHight = c.collider.bounds.size.y;
		float x;
		if (c.gameObject.name == "RacketPlayer1")
		{
			x = 1;
		}
		else
		{
			x = -1;
		}

		float y = (ballPosition.y - racketPosition.y) / racketHight;
		this.ball.increaseHitCounter();
		this.ball.MoveBall(new Vector2(x, y));
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2")
		{
			this.BounceFromRacket(collision);
		}
        else if (collision.gameObject.name == "WallLeft")
        {
            //Player 2 gets a point
            this.scoreController.GoalPlayer2();
			//Reset
			StartCoroutine(this.ball.StartBall(true));
        }

        else if (collision.gameObject.name == "WallRight")
        {
            //Player 1 gets a point
            this.scoreController.GoalPlayer1();
            //Reset
            StartCoroutine(this.ball.StartBall(false));
        }

    }
}
