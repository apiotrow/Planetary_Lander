using UnityEngine;
using System.Collections;

public class SupplyBoxFallOff : MonoBehaviour
{
	
	float supplyBoxImp; //supply box impact velocity holder
	public SupplyBoxController supplyBox; //supply box impact
	public float impactThresh; //threshold for parts falling off
	public GameObject player;
	public GameObject terra;
	
	void Start ()
	{
		//initial values in order to keep items on box
		rigidbody.isKinematic = true;
		collider.isTrigger = true;
		
	}
	
	void Update ()
	{
		supplyBoxImp = supplyBox.ImpactVel;
		impactThresh = 1f;
	
		
		
		//This code checks if the box's impact was high enough
		//to cause things to fall off. It then falls through
		//the attachments and breaks them off according to health
		//threshold
		if (Mathf.Abs (supplyBoxImp) > impactThresh && renderer.enabled) {
			if (rigidbody.name == "Corner1" 
			    && rigidbody.isKinematic == true
			    && supplyBox.Health < 95) {
				rigidbody.isKinematic = false;
				collider.isTrigger = false;
				transform.parent = null;
			}

			if (rigidbody.name == "Corner2" 
			    && rigidbody.isKinematic == true
			    && supplyBox.Health < 95) {
				rigidbody.isKinematic = false;
				collider.isTrigger = false;
				transform.parent = null;
			}

			if (rigidbody.name == "Corner3" 
			    && rigidbody.isKinematic == true
			    && supplyBox.Health < 90) {
				rigidbody.isKinematic = false;
				collider.isTrigger = false;
				transform.parent = null;
			}

			if (rigidbody.name == "Corner4" 
			    && rigidbody.isKinematic == true
			    && supplyBox.Health < 85) {
				rigidbody.isKinematic = false;
				collider.isTrigger = false;
				transform.parent = null;
			}

			if (rigidbody.name == "Corner5" 
			    && rigidbody.isKinematic == true
			    && supplyBox.Health < 85) {
				rigidbody.isKinematic = false;
				collider.isTrigger = false;
				transform.parent = null;
			}

			if (rigidbody.name == "Corner6" 
			    && rigidbody.isKinematic == true
			    && supplyBox.Health < 80) {
				rigidbody.isKinematic = false;
				collider.isTrigger = false;
				transform.parent = null;
			}

			if (rigidbody.name == "Corner7" 
			    && rigidbody.isKinematic == true
			    && supplyBox.Health < 75) {
				rigidbody.isKinematic = false;
				collider.isTrigger = false;
				transform.parent = null;
			}

			if (rigidbody.name == "Corner8" 
			    && rigidbody.isKinematic == true
			    && supplyBox.Health < 70) {
				rigidbody.isKinematic = false;
				collider.isTrigger = false;
				transform.parent = null;
			}


			

		}
		
		
		
		//rigidbody.isKinematic = false;
		//transform.parent = null;
		//rigidbody.detectCollisions = true;
		//rigidbody.constraints = RigidbodyConstraints.None;
		//collider.isTrigger = true;
	}
	
	void OnCollisionEnter (Collision collision)
	{
	}
}
