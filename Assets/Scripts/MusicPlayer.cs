using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Awake () { // awake runs before start
		SetUpSingleton();
	}

	private void SetUpSingleton()
	{
		if (FindObjectsOfType(GetType()).Length > 1)  // gettype is this objects type
		{
			Destroy(gameObject); //  if there is already an instance then estroy self
		}
		else
		{
			DontDestroyOnLoad(gameObject); // make sure this object persist between loads
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
