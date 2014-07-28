using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public bool inRecep;

	// Use this for initialization
	void Start () {
		inRecep = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision)
	{

		if (inRecep == false && collision.gameObject.tag == "ReceptacleFloor") {
			//Debug.Log ("hit it");
			inRecep = true;
		}
	}
}
