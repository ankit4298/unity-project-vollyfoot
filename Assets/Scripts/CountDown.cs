using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
	public int totalGameTime = 90;
	private int timeleft;
	public Text gameTime;   // UI object
	public TextMeshProUGUI winnerAnnouncement;
	public GameObject endMenuUI;

	void Start()
	{
		StartCoroutine("LoseTime");
		timeleft = totalGameTime;
		//Time.timeScale = 1;
	}

	void Update()
	{

		if (timeleft <= 10)
		{
			gameTime.color = Color.red;
		}

		if (timeleft == 0)
		{

            GameOver();
		}
		gameTime.text = ("" + timeleft);
	}

	IEnumerator LoseTime()
	{
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeleft--;
		}
	}

	void GameOver()
	{
		gameTime.text = "" + "Time's UP !";
		// open end game menu

		int winner = GameManager.leftPlayerScore.CompareTo(GameManager.rightPlayerScore);
		if (winner < 0)
		{
			//right won
			winnerAnnouncement.text = "Player 2 Won !";
		}
		else if (winner > 0)
		{
			// left won
			winnerAnnouncement.text = "Player 1 Won !";
		}
		else
		{
			// tie
			winnerAnnouncement.text = "It's a TIE !";
		}

		endMenuUI.SetActive(true);


        // stop game
        Time.timeScale = 0f;
	}




}
