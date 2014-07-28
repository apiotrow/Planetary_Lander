using UnityEngine;
using System.Collections;

public class HitTerrain : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Terrain") {
			//Debug.Log ("hit it");
			//expl = Resources.Load <AudioClip>("blast");
			//audio.Play();
			collider.isTrigger = true;
			//AudioSource.PlayClipAtPoint(expl[0], Vector3.zero);

			
		}
	}
	void OnCollisionExit (Collision collision)
	{
		if (collision.gameObject.tag == "Terrain") {
			//Debug.Log ("hit it");
			//expl = Resources.Load <AudioClip>("blast");
			//audio.Play();
			collider.isTrigger = false;
			//AudioSource.PlayClipAtPoint(expl[0], Vector3.zero);
			
			
		}
	}
}
