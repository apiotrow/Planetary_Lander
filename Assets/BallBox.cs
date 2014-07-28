using UnityEngine;
using System.Collections;

public class BallBox : MonoBehaviour {
	public bool connected; //is the ball box connecte to the ship?
	public PlayerController player;

	// Use this for initialization
	void Start () {
		connected = false;

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= (player.transform.position.y + 10)) {
			connected = true;
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		//check if we're in the lowering phase. if we're not in that
		//phase, we don't want to check for collisions
		if (player.makeBoxLower && collision.gameObject.tag == "Player") {
			//Debug.Log ("hit it");
			//connected = true;
		}
	}
}
