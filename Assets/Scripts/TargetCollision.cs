using UnityEngine;
using UnityEngine.UI;

public class TargetCollision : MonoBehaviour
{

	public GameObject particleSys;


	void OnCollisionEnter2D(Collision2D coll)
	{

		if (coll.gameObject.CompareTag("ball"))
		{
			if (gameObject.tag == "targetleft")
			{
				GameManager.rightPlayerScore++;
				GameManager.nextServe = true;
				Destroy(coll.gameObject, 0.1f);
				ActivateParticleSystem();

                FindObjectOfType<AudioManager>().Play("ShortWhistle");

            }
			if (gameObject.tag == "targetright")
			{
				GameManager.leftPlayerScore++;
				GameManager.nextServe = true;
				Destroy(coll.gameObject,0.1f);
				ActivateParticleSystem();

                FindObjectOfType<AudioManager>().Play("ShortWhistle");

            }
		}


		// // // // old script which lied on ball game Object

		//if (coll.tag == "targetleft")
		//{
		//	GameManager.rightPlayerScore++;
		//	nextServe = 1;  // player 1 will serve

		//	//GameObject

		//}
		//else if (coll.tag == "targetright")
		//{
		//	GameManager.leftPlayerScore++;
		//	nextServe = 2;  // player 2 will serve
		//}

		//Destroy(gameObject, 0.1f);

	}

	void ActivateParticleSystem()
	{
		GameObject goal = Instantiate(particleSys, particleSys.GetComponent<Transform>().position, Quaternion.identity);
		goal.GetComponent<ParticleSystem>().Play();
		Destroy(goal, 3f);
	}



}