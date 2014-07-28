using UnityEngine;
using System.Collections;

public class Hut : MonoBehaviour {
	public float rotator;
	public GameObject pauser;
	public Pausation ps;
	// Use this for initialization
	void Start () {
		rotator = 0;
		pauser = GameObject.FindGameObjectWithTag ("Pauser");
		ps = pauser.GetComponent<Pausation>();
		transform.eulerAngles = new Vector3(-90, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (!ps.paused) {
			//rotator += .25f;
			transform.eulerAngles = new Vector3 (-90, rotator, 0);
		}
	}
}
