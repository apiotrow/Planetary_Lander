using UnityEngine;
using System.Collections;

public class Controls : MonoBehaviour {
	
	private bool display = false;
	
	void OnGUI () {
		// Make a background box
		
		if (GUI.Button(new Rect(10, 10, 100, 30), "Controls:")) {
			display =! display;
			
		}
		
		if (display) {
			GUI.Box(new Rect(10,40,170,30), "W - Tilt Forward (Pitch Up)");
			GUI.Box(new Rect(10,70,170,30), "A - Tilt Left (Yaw Left)");
			GUI.Box(new Rect(10,100,190,30), "S - Tilt Backward (Pitch Back)");
			GUI.Box(new Rect(10,130,170,30), "D - Tilt Right (Yaw Right)");
			GUI.Box(new Rect(10,160,170,30), "Space - Thrust");
			GUI.Box(new Rect(10,190,170,30), "Left Arrow - Turn Left");
			GUI.Box(new Rect(10,220,170,30), "Right Arrow - Turn Right");
			GUI.Box(new Rect(10,250,170,30), "P - Pause Game");
			GUI.Box(new Rect(10,280,170,30), "C - Super Thrust");
			GUI.Box(new Rect(10,310,170,30), "X - Fast Flip");
		}

		if (GUI.Button (new Rect (Screen.width - 100, 0, 100, 30), "Tutorial")) {
			Application.LoadLevel ("Tutorial");
		}
	}
	
}