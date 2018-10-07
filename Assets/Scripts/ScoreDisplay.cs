using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // text is part of UI so need this

public class ScoreDisplay : MonoBehaviour {

	Text scoreText;
	GameSession gameSession;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text>(); // ref to the Text component on this object
		//gameSession = FindObjectOfType<GameSession>(); // ReferenceEquals to the game session
		gameSession = GameSession.instance;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(gameSession.GetInstanceID());
		scoreText.text = gameSession.GetScore().ToString();
	}
}
