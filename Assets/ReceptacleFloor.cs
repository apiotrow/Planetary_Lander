using UnityEngine;
using System.Collections;

public class ReceptacleFloor : MonoBehaviour {
	public int numBallInside;
	public string done;

	// Use this for initialization
	void Start () {
		done = "BallDone";
		numBallInside = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//only works if we don't make it a trigger
	//used if we want to count the ball that land on
	//the bottom and touch it
	/*
	void OnCollisionEnter (Collision collision)
	{
		
		if (collision.gameObject.tag == "Ball") {
			//Debug.Log ("hit it");
			numBallInside += 1;
			collision.gameObject.tag = "BallDone";
		}
	}
	*/

	//only works if we make it a trigger
	//used if we want to count if balls just
	//landed in the bounds. better because balls
	//can also stack on each other and never touch
	//the bottom
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Ball") {
			//Debug.Log ("hi");
			numBallInside += 1;
			other.tag = done;

		}
	}
}
