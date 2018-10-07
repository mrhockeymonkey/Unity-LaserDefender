using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	[SerializeField] float gameOverDelay = 2;

	private IEnumerator DelayGameOver()
	{
		yield return new WaitForSeconds(gameOverDelay);
		SceneManager.LoadScene("Over");
	}

	public void LoadGameOver()
	{
		StartCoroutine(DelayGameOver());
	}

	public void LoadGameScene()
	{
		SceneManager.LoadScene("Game");
	}

	public void LoadStartMenu()
	{
		FindObjectOfType<GameSession>().ResetScore();
		SceneManager.LoadScene("Start");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
