using UnityEngine;
using System.Collections;

public class MeteorController : MonoBehaviour {
	public GameObject meteor;
	public float spawnDelay = 2f;
	public float nextSpawn = 2f;
	public GameObject pauser;
	public Pausation ps;

	// Initialize delays
	void Start(){
		pauser = GameObject.FindGameObjectWithTag ("Pauser");
		ps = pauser.GetComponent<Pausation>();
		nextSpawn = Time.time + spawnDelay;
	}

	// Function to retrieve random point with respect to the controller plane
	Vector3 getRandomPosition()
	{
		Vector3 randomPoint = transform.TransformPoint (new Vector3 (Random.Range (-5.0f, 5.0f), 200f, Random.Range (-5f, 5f)));
		return randomPoint;
	} 

	// Instantiate function to be called by Invoke()
	void Instantiate(){
		Instantiate (meteor, getRandomPosition(), transform.rotation);
	}

	// Update is called once per frame
	void Update () {
		if (!ps.paused) {
			if (Time.time > nextSpawn) {
				nextSpawn = Time.time + spawnDelay + Random.Range (-1f, 1f);
				Invoke ("Instantiate", 5f);
			}
		}
	}
}
