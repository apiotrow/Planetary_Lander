using UnityEngine;
using System.Collections;

public class SupplyBoxController : MonoBehaviour {
	public Vector3 collVec; //for holding collision vector
	public float impactVel; //holds impact velocity
	public GameObject player;
	public GameObject terra;

	//Allows other scripts to access the impactVel variable
	public float ImpactVel {
		get {
			return impactVel;
		}
	}

	public float health; //holding box's health

	//Allows other scripts to access box's health
	public float Health {
		get {
			return health;
		}
	}

	// Use this for initialization
	void Start () {
		impactVel = 0;
		health = 100; //player max health = 100
	}
	
	// Update is called once per frame
	void Update () {
		if (!renderer.enabled) {
			Physics.IgnoreCollision(this.collider, player.collider);
			Physics.IgnoreCollision (this.collider, terra.collider);
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		//When box impacts thing, lower health
		if (collision.gameObject.tag == "Terrain") {
			collVec = collision.contacts [0].point - transform.position;
			impactVel = Vector3.Dot (collVec.normalized, rigidbody.velocity);
			//Debug.Log (health);
			health -= Mathf.Sqrt (Mathf.Abs (impactVel));
		}
	}
}
