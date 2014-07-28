using UnityEngine;
using System.Collections;

public class FallOffMM : MonoBehaviour
{
	
	float playerImp; //holds player impact velocity
	public float impactThresh; //threshold for things falling off
	
	void Start ()
	{
		rigidbody.isKinematic = true;
		collider.isTrigger = true;
		rigidbody.mass = 0.0001f;
		
	}

	void Update ()
	{

			
		}
		

	

}
