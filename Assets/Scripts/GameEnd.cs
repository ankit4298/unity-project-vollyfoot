using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
	public GameObject endGameUI;
	private const string menuSceneName = "MainMenu";
	private const string startNewGame = "GameScene";


	public void StartNewGame()
	{
		SceneManager.LoadScene(startNewGame);
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene(menuSceneName);
		// reset player scores in GameManagement
	}

	public void Quit()
	{
		Application.Quit();
	}
}
