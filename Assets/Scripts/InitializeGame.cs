using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : MonoBehaviour
{

	[SerializeField] private Transform ballSpawn;
	[SerializeField] private GameObject ball;

	void Start()
	{
		// reset scores of player -- as it may load last game scores
		GameManager.leftPlayerScore = 0;
		GameManager.rightPlayerScore = 0;

		// Unfreeze time as Game is about to start
		Time.timeScale = 1f;

		Instantiate(ball, ballSpawn.position, ballSpawn.rotation);

	}


}
