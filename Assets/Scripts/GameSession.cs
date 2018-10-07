using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour {

	[SerializeField] int score;
	[SerializeField] int id;
	public static GameSession instance;

	// Use this for initialization
	void Awake() 
	{
		id = GetInstanceID();
		//Singleton();
		SingletonLiz();
	}

	private void SingletonLiz()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else{
			Destroy(gameObject);
		}
	}

	private void Singleton()
	{
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
		else{
			DontDestroyOnLoad(gameObject);
		}
	}
	
	public int GetScore()
	{
		return score;
	}

	public void AddToScore(int val)
	{
		score += val;
	}

	public void ResetScore()
	{
		score = 0;
	}
}
