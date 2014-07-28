using UnityEngine;
using System.Collections;

public class RopePU : MonoBehaviour {
	public GameObject tarPU;
	public GameObject rope;
	public GameObject hitch;
	public GameObject tarDrop;
	public ConfigurableJoint cj;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject == tarPU) {
			Destroy(tarPU);
			Instantiate(rope, hitch.transform.position, transform.rotation);

			//cj.connectedBody = gameObject.rigidbody;
		}
		if (other.gameObject == tarDrop) {
			//cj.connectedBody = null;
		}
	}
}
