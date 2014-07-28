using UnityEngine;
using System.Collections;

public class LandingPad : MonoBehaviour {
	public int num;
	public GameObject arrow;
	public GameObject beacon;
	public Point pt;
	// Use this for initialization
	void Start () {
		arrow = GameObject.FindGameObjectWithTag ("Arrow");
		pt = arrow.GetComponent<Point>();
	}
	
	// Update is called once per frame
	void Update () {
		if (pt.num == num) {
			beacon.renderer.enabled = true;
		} else {
			beacon.renderer.enabled = false;
		}
	}
}
