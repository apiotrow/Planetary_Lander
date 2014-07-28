using UnityEngine;
using System.Collections;

public class RenderFlip : MonoBehaviour {
	public int num;
	public Vector3 storedVel;
	public GameObject pauser;
	public Pausation ps;
	public Vector3 storedPos;
	// Use this for initialization
	void Start () {
		pauser = GameObject.FindGameObjectWithTag ("Pauser");
		ps = pauser.GetComponent<Pausation>();
	}
	void Update(){
		if (!ps.paused) {
			if(rigidbody != null){
				storedVel = rigidbody.velocity;
				storedPos = transform.position;
				StartCoroutine (PauseWait ());
			}
		} else {
			if(rigidbody != null){
				//rigidbody.Sleep ();
				rigidbody.isKinematic = true;
				//StartCoroutine(PauseWait ());
				rigidbody.useGravity = false;
				rigidbody.velocity = new Vector3 (0,0,0);
				//transform.position = new Vector3 (0,0,0);
				rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
			}
		}
	}
	// Update is called once per frame
	void RenderSwap(int butt){
		if (!ps.paused) {
			if (num == butt) {
				if (renderer == null) {
					return;
				}
				if ((tag == "Rope" || tag == "SBox") && renderer.enabled) {
					//rigidbody.useGravity = false;
					collider.isTrigger = true; 
					rigidbody.mass = 0.0000001f;
					//rigidbody.detectCollisions = false;
				} else if ((tag == "Rope" || tag == "SBox") && !renderer.enabled) {
					collider.isTrigger = true;
					rigidbody.mass = 1f;
				}
				renderer.enabled = !renderer.enabled;
			}
		}
	}
	
	IEnumerator PauseWait ()
	{
		//delay on pause
		yield return new WaitForSeconds (.1f);
		//ps.paused = false;
		//rigidbody.WakeUp ();
		rigidbody.isKinematic = false;
		rigidbody.useGravity = true;
		rigidbody.velocity = storedVel;
		transform.position = storedPos;
		rigidbody.constraints = RigidbodyConstraints.None;
		//rigid
	}
}

