using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
	
	//public bool onQuit = false;
	
	void OnMouseOver() {
		renderer.material.color = Color.red;
	}
	
	void OnMouseExit() {
		renderer.material.color = Color.white;
	}
	
	void OnMouseDown() {
		Debug.Log ("I was clicked");
		if (GameObject.Find ("Restart")) {
			Application.LoadLevel("Main Menu");
		}
	}
}
