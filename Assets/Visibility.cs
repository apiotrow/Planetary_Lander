using UnityEngine;
using System.Collections;

public class Visibility : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			renderer.enabled = true;
		} else {

			renderer.enabled = false;
		}
	}
}
