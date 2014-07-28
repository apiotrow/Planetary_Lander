using UnityEngine;
using System.Collections;

public class Pausation : MonoBehaviour {
	public bool paused;
	public bool options;
	public string currentMenu;
	public string showMenu;

	// Use this for initialization
	void Start () {
		paused = false;
		//Pause1 = GameObject.FindGameObjectWithTag ("Pause");
	}

	// Update is called once per frame
	void Update () {
		/*if (paused) {
			current
		}*/
	}

	void OnGUI() {
		if(currentMenu == "Main")
			Menu_Main();
		if(currentMenu == "Opt")
			Menu_Opt();
	}

	public void Menu_Main() {
		GUI.Label(new Rect(10, 10, 200, 50), "Paused");
		if(GUI.Button(new Rect(10, 70, 200, 50), "Options")) {
			//NavigateTo("Opt");
		}
	}
	
	public void Menu_Opt() {
		GUI.Label(new Rect(10, 10, 200, 50), "Options");
		if(GUI.Button(new Rect(10, 70, 200, 50), "Back")) {
			//NavigateTo("Main");
		}      
	}
}
