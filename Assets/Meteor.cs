using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {
	public GameObject explosion;

	// Declare/initialize variables
	public int bounceMax = 3;
	public float minFallSpeed = 150f;
	public float maxFallSpeed = 350f;
	public float minScale = -5f;
	public float maxScale = 5f;
	public float levelSize = 150f;

	private int bounceCount = 0;
	private float fallSpeed = 10f;
	private float meteorScale = 1f;
	private float dirX;
	private float dirZ;
	private float rotX;
	private float rotY;
	private float rotZ;
	private bool bouncing = false;
	public GameObject pauser;
	public Pausation ps;
	
	void Start(){
		pauser = GameObject.FindGameObjectWithTag ("Pauser");
		ps = pauser.GetComponent<Pausation>();
		// Set variables per instance of object
		fallSpeed = Random.Range (minFallSpeed, maxFallSpeed);
		meteorScale = Random.Range (minScale, maxScale);
		dirX = Random.Range (-levelSize, levelSize);
		dirZ = Random.Range (-levelSize, levelSize);
		rotX = Random.Range (-30f, 30f);
		rotY = Random.Range (-100f, 100f);
		rotZ = Random.Range (-45f, 45f);

		// Apply scale transformation
		transform.localScale = new Vector3 (meteorScale * 8f, meteorScale * 8f, meteorScale * 8f);
	}

	// Update is called once per frame
	void Update () {
		if (!ps.paused) {
			// Sends meteor with downwards velocity
			// Physics.gravity = new Vector3 (dirX, -fallSpeed, dirZ);
			if (!bouncing) {
				transform.rigidbody.velocity = new Vector3 (dirX, -fallSpeed, dirZ);
			}

			// Applies rotation to meteor
			transform.Rotate (rotX * Time.deltaTime, rotY * Time.deltaTime, rotZ * Time.deltaTime);
		}
	}

	void OnCollisionEnter(Collision c){
		if (!ps.paused) {
			// Increment bounceCount
			++bounceCount;

			// Spawn explosions on collisions, and destroy this object when it runs out of bounces
			if (c.gameObject.tag == "Terrain" || c.gameObject.tag == "Player") {
				//Debug.Log ("hit it");
				explosion.transform.localScale = new Vector3 (transform.lossyScale.x * 4f, transform.lossyScale.y * 4f, transform.lossyScale.z * 4f);
				Instantiate (explosion, transform.position, transform.rotation);
			}
			if (bounceCount == bounceMax) {
				GameObject.Destroy (gameObject);
			}

			//
			bouncing = true;
			Invoke ("bounceReset", 1.0f);
		}
	}

	void bounceReset(){
		bouncing = false;
		fallSpeed = 100f;
		transform.rigidbody.velocity += new Vector3 (0f, -fallSpeed, 0f);
	}
}
