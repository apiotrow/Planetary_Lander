using UnityEngine;
using System.Collections;

public class Fuel : MonoBehaviour {
	public GameObject player;
	public PlayerController pc;
	public float fuelMax;
	public float fuelCurr;
	public float fuelOff;
	public float fuelPer;
	public float yCap;
	// Use this for initialization
	void Awaken () {
		//set player and set fuel cap
		player = GameObject.FindGameObjectWithTag ("Player");
		pc = player.GetComponent<PlayerController> ();
		fuelMax = pc.fuelCap;
		fuelCurr = fuelMax;
	}
	
	// Update is called once per frame
	void Update () {
		//consume fuel based on the percentage left and shift it into place
		fuelMax = pc.fuelCap;
		fuelCurr = pc.fuelCurr;
		fuelPer = fuelCurr / fuelMax;
		fuelOff = .98f - fuelPer;
		transform.localScale = new Vector3(0.25f,(.55f * fuelPer),0.25f);
		transform.localPosition = new Vector3 (transform.localPosition.x, -fuelOff/2, transform.localPosition.z);
	}
}
