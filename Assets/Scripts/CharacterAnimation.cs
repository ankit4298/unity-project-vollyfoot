using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{

	private Animator anim;
	private bool isCheeringP1;
	private bool isCheeringP2;

	private bool isCheering;

	void Start()
	{
		anim = GetComponent<Animator>();
		isCheeringP1 = true;
		isCheeringP2 = true;

		isCheering = true;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			anim.SetBool("isCheeringP1", isCheeringP1);
			isCheeringP1 = !isCheeringP1;
		}

		if (Input.GetKeyDown(KeyCode.Keypad9))
		{
			anim.SetBool("isCheeringP2", isCheeringP2);
			isCheeringP2 = !isCheeringP2;
		}

		if (Input.GetKeyDown(KeyCode.H))
		{
			anim.SetBool("isCheering", isCheering);
			isCheering = !isCheering;
		}

	}


}
