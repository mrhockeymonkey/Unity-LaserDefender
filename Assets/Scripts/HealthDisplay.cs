using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

	Text healthText;
	Player player;

	// Use this for initialization
	void Start () {
		healthText = GetComponent<Text>(); // ref to the Text component on this object
		player = FindObjectOfType<Player>(); // ReferenceEquals to the game session
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(player.GetInstanceID());
		healthText.text = player.GetHealth().ToString();
	}
}
