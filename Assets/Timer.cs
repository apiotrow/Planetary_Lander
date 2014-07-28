using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	//public int score;
	float timer = 90.0f;
	
	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(10,10,100,30), "Timer: " + timer.ToString("0"));
		//GUI.Button (new Rect (Screen.width - 120, 10, 110, 30), "Landed On: " + (Mathf.Floor (score)).ToString () );
	}

	void Update()
	{
		timer -= Time.deltaTime;
		if(timer < 0)
		{
			Application.Quit ();
		}
	}
}