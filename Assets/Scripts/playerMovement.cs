using UnityEngine;

public class playerMovement : MonoBehaviour
{

	public static playerMovement playerMovementObject;

	CharacterController player1;
	CharacterController player2;

	public KeyCode jumpKey;

	public float speed = 5f;
	public float jumpForce = 0.5f;
	public Rigidbody2D rb;

	// jump vars
	private bool isGrounded;
	public Transform groundCheck;
	public float checkRadius;
	public LayerMask groundLayer;

	private float jumpTimeCounter;
	public float jumpTime = 0.35f;
	private bool isJumping;

	public GameObject ball;
	public Transform locationOfSpawn;
	private GameObject spawnedObj = null;
	private float waitTimeUntilNextServe = 2f;
	private float timeLeftForServe;
	private bool isWaiting = false;

	void Start()
	{

		playerMovementObject = this;

		player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<CharacterController>();
		player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{

		// next serve logic with delay 
		if (GameManager.nextServe)
		{
			timeLeftForServe -= Time.deltaTime;
		}
		else
		{
			isWaiting = false;
		}



		if (!GameManager.nextServe)
		{
			isWaiting = false;
		}
		if (GameManager.nextServe)
		{
			if (!isWaiting)
			{
				timeLeftForServe = waitTimeUntilNextServe;
				isWaiting = true;
			}

			if (timeLeftForServe < 0)
			{
                FindObjectOfType<AudioManager>().Play("LongWhistle");

				SpawnBall();
			}

		}


		// jumping logic
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
		if (isGrounded == true && Input.GetKeyDown(jumpKey))
		{
			isJumping = true;
			jumpTimeCounter = jumpTime;
			rb.velocity = Vector2.up * jumpForce;
		}
		if (Input.GetKey(jumpKey) && isJumping == true)
		{
			if (jumpTimeCounter >= 0)
			{
				rb.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
			}
			else
			{
				isJumping = false;
			}

		}
		if (Input.GetKeyUp(jumpKey))
		{
			isJumping = false;
		}






	}

	void FixedUpdate()
	{

		if (this.gameObject.tag == "Player1")
		{
			float movement1 = Input.GetAxis("P1_Horizontal");
			rb.velocity = new Vector2(movement1 * speed, rb.velocity.y);


			if (movement1 > 0)
			{
				transform.eulerAngles = new Vector3(0, 0, 0);
			}
			else if (movement1 < 0)
			{
				transform.eulerAngles = new Vector3(0, 180, 0);
			}
		}



		if (this.gameObject.tag == "Player2")
		{
			float movement2 = Input.GetAxis("P2_Horizontal");
			rb.velocity = new Vector2(movement2 * speed, rb.velocity.y);

			if (movement2 > 0)
			{
				transform.eulerAngles = new Vector3(0, 0, 0);
			}
			else if (movement2 < 0)
			{
				transform.eulerAngles = new Vector3(0, 180, 0);
			}
		}



	}


	void SpawnBall()
	{
		spawnedObj = Instantiate(ball, locationOfSpawn.position, locationOfSpawn.rotation);
		GameManager.nextServe = false;
	}


	public float getMovementSpeed()
	{
		return speed;
	}
	public void setMovementSpeed(float incSpeed)
	{
		speed += incSpeed;
	}

	public static void incSpeed(GameObject player,float incSpeed)
	{

		playerMovementObject.speed = incSpeed;
	}


}
