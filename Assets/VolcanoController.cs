using UnityEngine;
using System.Collections;

public class VolcanoController : MonoBehaviour {
	public GameObject rock;
	public int rocksPerExplosion = 4;
	public float spawnDelay = 2f;
	public float nextSpawn = 1f;
	public GameObject pauser;
	public Pausation ps;
	
	// Initialize delays
	void Start(){
		pauser = GameObject.FindGameObjectWithTag ("Pauser");
		ps = pauser.GetComponent<Pausation>();
		nextSpawn = Time.time + spawnDelay;
	}
	
	// Function to retrieve random point with respect to the controller plane
	Vector3 getRandomPosition(){
			Vector3 randomPoint = transform.TransformDirection (new Vector3 (transform.position.x + Random.Range (-50f, 50f), transform.position.y + 70f, transform.position.z + Random.Range (-50f, 50f)));
		
			return randomPoint;
		
	} 
	
	// Explode function to be called` in Update()
	void explode(){
		if (!ps.paused) {
			for (int i = 0; i <= rocksPerExplosion; ++i) {
				Instantiate (rock, getRandomPosition (), transform.rotation);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!ps.paused) {
			if (Time.time > nextSpawn) {
				nextSpawn = Time.time + spawnDelay;
				explode ();
			}
		}
	}
}
