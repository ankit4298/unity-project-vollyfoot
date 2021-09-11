using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public static bool isGamePaused = false;
	public GameObject pauseMenuUI;

	private const string MenuSceneName = "MainMenu";

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (isGamePaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		Time.timeScale = 1f;
		isGamePaused = false;
		pauseMenuUI.SetActive(false);
	}

	void Pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isGamePaused = true;
	}

	public void LoadMenu()
	{
		SceneManager.LoadScene(MenuSceneName);
		// reset player scores in GameManagement
	}

	public void Quit()
	{
		Application.Quit();
	}


}
