using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerPowerUp : MonoBehaviour
{
	public KeyCode powerUp1;
	public KeyCode powerUp2;
	public KeyCode powerUp3;
	public KeyCode powerUp4;

	public GameObject opponent;
	private Rigidbody2D selfRigidBody;
	private Rigidbody2D opponentRigidBody;

	public enum POWERUPS { NONE, FREEZE_OPP, SHRINK_TARGET, DEC_GRAVITY_BALL, SMASH, INC_PLAYER_MOV_SPEED };
	private POWERUPS usingPower = POWERUPS.NONE;
	private float powerUpDuration;
	private bool isPowerUpInUse = false;

	private PlayerPowerUpsData pdata;

	public Animator targetLeftShrinkAnimation;
	public Animator targetRightShrinkAnimation;

	public static bool playerNearBall = false;

	public TextMeshProUGUI powerUpText;


	void Start()
	{
		selfRigidBody = gameObject.GetComponent<Rigidbody2D>();
		opponentRigidBody = opponent.GetComponent<Rigidbody2D>();

		pdata = new PlayerPowerUpsData();
	}

	void Update()
	{

		updatePowerUpInfo();



		if (Input.GetKeyDown(powerUp1))
		{
			// apply freeze power up
			usingPower = POWERUPS.FREEZE_OPP;
			FreezeOpponent();
			powerUpDuration = pdata.getPowerUpDuration(usingPower) * 100;   // *100 for milliseconds
			isPowerUpInUse = true;
		}

		if (Input.GetKeyDown(powerUp2))
		{
			usingPower = POWERUPS.SHRINK_TARGET;
			ShrinkTarget();
			powerUpDuration = pdata.getPowerUpDuration(usingPower) * 100;
			isPowerUpInUse = true;
		}

		if (Input.GetKeyDown(powerUp3))
		{
			// no time duration applying force only one time
			SmashShot(GameObject.FindGameObjectWithTag("ball"), 250f);
		}

		//if (Input.GetKeyDown(powerUp4))
		//{
		//	usingPower = POWERUPS.INC_PLAYER_MOV_SPEED;
		//	IncreasePlayerMovementSpeed();
		//	powerUpDuration = pdata.getPowerUpDuration(usingPower) * 100;
		//	isPowerUpInUse = true;
		//}











		if (isPowerUpInUse)
		{
			//Debug.Log(powerUpDuration);
			powerUpDuration -= Time.deltaTime * 100;

			if (powerUpDuration < 0)
			{
				// remove all illeffects
				isPowerUpInUse = false;
				removeIllEffects(usingPower, selfRigidBody, opponentRigidBody);
				usingPower = POWERUPS.NONE;
			}
		}


	}   // update END




	#region trigger for smash Power up

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.CompareTag("ball"))
		{
			playerNearBall = true;
		}
	}

	void OnTriggerExit2D()
	{
		playerNearBall = false;
	}

	#endregion



	#region power up definations

	// power up functions
	void FreezeOpponent()
	{
		opponentRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
	}

	void ShrinkTarget()
	{
		GameObject target;
		if (gameObject.CompareTag("Player1"))
		{
			target = GameObject.FindGameObjectWithTag("targetleft");
			targetLeftShrinkAnimation.SetBool("shrinkLeft", true);
		}
		else
		{
			target = GameObject.FindGameObjectWithTag("targetright");
			targetRightShrinkAnimation.SetBool("shrinkRight", true);
		}
		target.transform.localScale = new Vector3(1f, 0.7f, 1f);
	}

	void SmashShot(GameObject ball, float force)
	{
		if (gameObject.CompareTag("Player1"))
		{
			if (playerNearBall)
			{
				Transform target = GameObject.FindGameObjectWithTag("targetright").GetComponent<Transform>();
				ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(target.position.x, target.position.y) * force);
			}
		}
		else
		{
			if (playerNearBall)
			{
				Transform target = GameObject.FindGameObjectWithTag("targetleft").GetComponent<Transform>();
				ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(target.position.x, target.position.y) * force);
			}

		}
	}

	void IncreasePlayerMovementSpeed()
	{
		playerMovement.playerMovementObject.speed = 15f;
	}






	// removing ill effects after duration is over
	void removeIllEffects(POWERUPS p, Rigidbody2D self, Rigidbody2D opponent)
	{
		if (p == POWERUPS.FREEZE_OPP)
		{
			opponent.constraints = RigidbodyConstraints2D.None;
		}
		if (p == POWERUPS.SHRINK_TARGET)
		{
			GameObject target;
			if (gameObject.CompareTag("Player1"))
			{
				target = GameObject.FindGameObjectWithTag("targetleft");
				targetLeftShrinkAnimation.SetBool("shrinkLeft", false);

			}
			else
			{
				target = GameObject.FindGameObjectWithTag("targetright");
				targetRightShrinkAnimation.SetBool("shrinkRight", false);

			}
			target.transform.localScale = new Vector3(1f, 1f, 1f);
		}


	}

	#endregion

	void updatePowerUpInfo()
	{
		powerUpText.text = "" + usingPower;
	}


}
