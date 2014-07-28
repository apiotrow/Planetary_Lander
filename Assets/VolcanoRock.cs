using UnityEngine;
using System.Collections;

public class VolcanoRock : MonoBehaviour {
	public GameObject explosion;
	
	// Declare/initialize variables
	public int bounceMax = 1;
	public float minFlySpeed = 1f;
	public float maxFlySpeed = 5f;
	public float minFallSpeed = 5f;
	public float maxFallSpeed = 10f;
	public float minScale = -2f;
	public float maxScale = 5f;
	
	private int bounceCount = 0;
	private float flySpeed = 10f;
	private float fallSpeed = 10f;
	private float rockScale = 5f;
	private float dirX;
	private float dirZ;
	private float rotX;
	private float rotY;
	private float rotZ;
	private bool flying = true;
	private bool bouncing = false;
	public GameObject pauser;
	public Pausation ps;
	
	void Start(){
		pauser = GameObject.FindGameObjectWithTag ("Pauser");
		ps = pauser.GetComponent<Pausation>();
		// Set variables per instance of object
		flySpeed = Random.Range (minFlySpeed, maxFlySpeed);
		fallSpeed = Random.Range (minFallSpeed, maxFallSpeed);
		rockScale = Random.Range (minScale, maxScale);
		dirX = Random.Range (-20, 20);
		dirZ = Random.Range (-20, 20);
		rotX = Random.Range (-30f, 30f);
		rotY = Random.Range (-100f, 100f);
		rotZ = Random.Range (-45f, 45f);
		
		// Apply scale transformation
		transform.localScale = new Vector3 (rockScale * 2f, rockScale * 2f, rockScale * 2f);
		// Turn flying false after timed delay
		Invoke ("falling", 2.5f);

		// Meteor lifespan fixed to 20 seconds max
		Invoke ("killMeteor", 15f);
	}

	// Update is called once per frame
	void Update () {
		if (!ps.paused) {
			// Physics.gravity = new Vector3 (dirX, -fallSpeed, dirZ);
			if (flying) {
				rigidbody.velocity = new Vector3 (dirX, flySpeed, dirZ);
			} else if (bouncing) {
				rigidbody.velocity = new Vector3 (dirX, fallSpeed, dirZ);
			} else {
				rigidbody.velocity = new Vector3 (dirX, -fallSpeed, dirZ);
			}
		
			// Applies rotation to meteor
			transform.Rotate (rotX * Time.deltaTime, rotY * Time.deltaTime, rotZ * Time.deltaTime);
		}
	}
	
	void OnCollisionEnter(Collision c){
		if (!ps.paused) {
			// Do nothing if VolcanoRock collides with another VolcanoRock or level's BoundingBox
			if (c.gameObject.tag == "Bound") {
				Physics.IgnoreCollision (collider, c.collider);
			}

			if (c.gameObject.tag == "VolcanoRock") {
				return;
			}

			// Increment bounceCount
			++bounceCount;

			// Spawn explosions on collisions, and destroy this object when it runs out of bounces
			if (c.gameObject.tag == "Terrain" || c.gameObject.tag == "Player") {
				//Debug.Log ("hit it");
				explosion.transform.localScale = new Vector3 (transform.lossyScale.x * 4f, transform.lossyScale.y * 4f, transform.lossyScale.z * 4f);
				Instantiate (explosion, transform.position, transform.rotation);
			}
			if (bounceCount == bounceMax) {
				killMeteor ();
			}
		
			// Set bouncing flag to true and start timer for flag toggle
			bouncing = true;
			Invoke ("bounceReset", 1.7f);
		}
	}

	// Turns off flying flag
	void falling(){
		if (!ps.paused) {
			flying = false;
		}
	}
	
	// Resets bounce timer and lowers fallSpeed
	void bounceReset(){
		if (!ps.paused) {
			bouncing = false;
			fallSpeed = 150f;
			rigidbody.velocity += new Vector3 (0f, -fallSpeed, 0f);
		}
	}

	void killMeteor(){
		if (!ps.paused) {
			GameObject.Destroy (gameObject);
		}
	}
}
