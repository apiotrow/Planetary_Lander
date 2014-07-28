using UnityEngine;
using System.Collections;

public class RotateLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, transform.up, Time.deltaTime * 1);
		transform.RotateAround (transform.position, transform.right, Time.deltaTime * 1);
		transform.RotateAround (transform.position, transform.forward, Time.deltaTime * 1);
	}
}
