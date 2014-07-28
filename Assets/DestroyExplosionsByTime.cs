using UnityEngine;
using System.Collections;

public class DestroyExplosionsByTime : MonoBehaviour {
	public float lifetime;
	// Use this for initialization
	void Start () {
		lifetime = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, lifetime);
	}
}
