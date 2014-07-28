using UnityEngine;
using System.Collections;

public class MoveBox : MonoBehaviour {
	public Transform target;
	Vector3 targetPos;
	Vector3 adjustment;
	float distLeft;
	public bool placed;
	public GameObject rope;
	public GameObject sBoxDrop;
	public GameObject sBoxPU;
	public bool canHit;
	public int num;
	// Use this for initialization
	void Start () {
		canHit = true;
		///adjustment = new Vector3 (0, 10f, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
		if (other.tag == "LZDrop" && renderer.enabled) {
			sBoxDrop.BroadcastMessage("RenderSwap", num);
			placed = true;
			//other.isTrigger = false;
			//other.transform.position = targetPos;
			//rope.BroadcastMessage("RenderSwap", num);
		}
		if (other.tag == "LZPU" && !placed) {
			sBoxPU.BroadcastMessage("RenderSwap", num);
			placed = true;
			//other.isTrigger = false;
			//other.transform.position = targetPos;
			//rope.BroadcastMessage("RenderSwap", num);
		}
		if((other.tag == "Shield" || other.tag == "Core") && canHit){
			rigidbody.velocity = new Vector3(-rigidbody.velocity.x, -rigidbody.velocity.y, -rigidbody.velocity.z);
			canHit = false;
			StartCoroutine(hitWait ());
		}
	}
	void OnTriggerExit(Collider other){
		if(other.tag == "LZPU2" && placed){
			collider.isTrigger = false;
			placed = false;
		}
	}
	IEnumerator hitWait(){
		yield return new WaitForSeconds(2f);
		canHit = true;
	}
}
