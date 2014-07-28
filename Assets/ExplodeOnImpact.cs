using UnityEngine;
using System.Collections;

public class ExplodeOnImpact : MonoBehaviour {
	public GameObject explosion;
	public AudioClip[] expl;

	// Use this for initialization
	void Start () {
		//expl = Resources.Load <AudioClip>("blast");
		/*
		expl = new AudioClip[]{
			Resources.Load ("blast") as AudioClip
		};
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Terrain") {
			//Debug.Log ("hit it");
			//expl = Resources.Load <AudioClip>("blast");
			//audio.Play();

			//AudioSource.PlayClipAtPoint(expl[0], Vector3.zero);
			Instantiate (explosion, transform.position, transform.rotation);
			Destroy (gameObject);

		}
	}
}
