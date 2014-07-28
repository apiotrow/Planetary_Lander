using UnityEngine;
using System.Collections;

public class OrbittingRingOfDeath : MonoBehaviour {
	public Transform target;
	public GameObject core;
	public CoreHealth corehp;
	public GameObject explosion;
	public GameObject pauser;
	public Pausation ps;
	//public float rotator;
	void Start(){
		pauser = GameObject.FindGameObjectWithTag ("Pauser");
		ps = pauser.GetComponent<Pausation>();
	}
	void Update(){
		//rotator += 1;
		if (!ps.paused) {
			if (target != null) {
				transform.RotateAround (target.position, Vector3.up, 20 * Time.deltaTime);
			}
		}
	}
	void OnCollisionEnter(Collision collision){
		if (!ps.paused) {
			ContactPoint contact = collision.contacts [0];
			if (contact.otherCollider.tag == "Wrecking" && target != null) {
				//Debug.Log ("Got here, homie");
				target = null;
				rigidbody.useGravity = true;
				rigidbody.isKinematic = false;
				Vector3 line = transform.position - contact.otherCollider.transform.position;
				rigidbody.AddForce (line * -20f);
				contact.otherCollider.attachedRigidbody.AddForce (line * 20f);
				corehp.hp -= 5;
				//collision.gameObject.rigidbody.velocity = new Vector3(-collision.gameObject.rigidbody.velocity.x*2, -collision.gameObject.rigidbody.velocity.y*2, -collision.gameObject.rigidbody.velocity.z*2);
			}
			if (contact.otherCollider.tag == "Terrain") {
				Instantiate (explosion, transform.position, transform.rotation);
				Destroy (gameObject);
			}
		}
	}
	void OnTriggerEnter(Collider other){
		if (!ps.paused) {
			if (other.tag == "BBoom") {
				Destroy (this.gameObject);
			}
		}
	}
}
