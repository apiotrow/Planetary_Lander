using UnityEngine;
using System.Collections;

public class FallOff : MonoBehaviour
{

	float playerImp; //holds player impact velocity
	public PlayerController player; //player object
	public float impactThresh; //threshold for things falling off

	void Start ()
	{
		rigidbody.isKinematic = true;
		collider.isTrigger = true;
		rigidbody.mass = 0.0001f;

	}

	/*
	 * Function to cause attachments on the ship to break off
	 * and shoot away and a specified velocity
	 * */
	void breakAway(string tagName, int healthThresh, float shootOffVel){
		if (rigidbody.name == tagName 
		    && rigidbody.isKinematic == true
		    && player.Health < healthThresh) {
			rigidbody.isKinematic = false;
			collider.isTrigger = false;

			//detach from parent
			transform.parent = null;
			Vector3 line = transform.position - player.transform.position;
			rigidbody.AddForce (line * shootOffVel);
		}
	}

	void Update ()
	{
		playerImp = player.ImpactVel; //impact that player hit ground with
		impactThresh = 0.1f;
		
		
		if (Mathf.Abs (playerImp) > impactThresh) {

			//Calls to make specific items break off
			breakAway ("Top", 85, 0.03f);
			breakAway ("CornerBracket1", 75, 0.03f);
			breakAway ("CornerBracket2", 70, 0.03f);
			breakAway ("CornerBracket3", 65, 0.03f);
			breakAway ("CornerBracket4", 60, 0.03f);
			breakAway ("Antenna", 50, 0.03f);
			breakAway ("Foot1", 45, 0.03f);
			breakAway ("Foot2", 40, 0.03f);
			breakAway ("Foot3", 35, 0.03f);
			breakAway ("Foot4", 30, 0.03f);
			breakAway ("Top", 20, 0.03f);
			
			
		}

	}

	void OnCollisionEnter (Collision collision)
	{
	}
}
