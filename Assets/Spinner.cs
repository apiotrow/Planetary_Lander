using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {
	public float rotator;
	public GameObject pauser;
	public Pausation ps;
	// Use this for initialization
	void Start () {
		rotator = 0;
		pauser = GameObject.FindGameObjectWithTag ("Pauser");
		ps = pauser.GetComponent<Pausation>();
	}
	
	// Update is called once per frame
	void Update () {
		//rotate the object when not paused.
		if (!ps.paused) {
			rotator += .25f;
			transform.eulerAngles = new Vector3 (0, rotator, 0);
		}
	}
}
