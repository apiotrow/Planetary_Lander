using UnityEngine;
using System.Collections;

public class ReadjustPositionSBox : MonoBehaviour {
	Vector3 adjust;
	// Use this for initialization
	void Start () {
		adjust = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerStay(Collider other){
		if (other.tag == "LZBuilding") {
			setPosition ();
		}
	}
	void setPosition(){
		transform.position = adjust;
	}
}
