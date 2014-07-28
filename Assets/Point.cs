using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {
	public Transform target;
	public Transform target2;
	public Transform target3;
	public Transform target4;
	public Transform target5;
	public Transform target6;
	public Transform target7;
	public Transform target8;
	Vector3 targetPos;
	public int num;
	public int cap;
	public GUIText score;
	// Use this for initialization
	void Start () {
		cap = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 3) {
			if (num == 0) {
				targetPos = target.transform.position;
				transform.LookAt (target);
				transform.RotateAround (transform.position, transform.up, 90);
			} else if (num == 1) {
				targetPos = target2.transform.position;
				transform.LookAt (target2);
				transform.RotateAround (transform.position, transform.up, 90);
			} else if (num == 2) {
				targetPos = target3.transform.position;
				transform.LookAt (target3);
				transform.RotateAround (transform.position, transform.up, 90);
			} else {
				//end condition met
			}
		} else if (Application.loadedLevel == 4) {
			if (num == 0) {
				if (target != null) {
					targetPos = target.transform.position;
					transform.LookAt (target);
					transform.RotateAround (transform.position, transform.up, 90);
				} else if (target2 != null) {
					targetPos = target2.transform.position;
					transform.LookAt (target2);
					transform.RotateAround (transform.position, transform.up, 90);
				}
			} else if (num == 1) {
				if (target3 != null) {
					targetPos = target3.transform.position;
					transform.LookAt (target3);
					transform.RotateAround (transform.position, transform.up, 90);
				} else if (target4 != null) {
					targetPos = target4.transform.position;
					transform.LookAt (target4);
					transform.RotateAround (transform.position, transform.up, 90);
				}
			} else if (num == 2) {
				if (target5 != null) {
					targetPos = target5.transform.position;
					transform.LookAt (target5);
					transform.RotateAround (transform.position, transform.up, 90);
				} else if (target6 != null) {
					targetPos = target6.transform.position;
					transform.LookAt (target6);
					transform.RotateAround (transform.position, transform.up, 90);
				}

			} else if (num == 3) {
				if (target7 != null) {
					targetPos = target7.transform.position;
					transform.LookAt (target7);
					transform.RotateAround (transform.position, transform.up, 90);
				} else if (target8 != null) {
					targetPos = target8.transform.position;
					transform.LookAt (target8);
					transform.RotateAround (transform.position, transform.up, 90);
				}
			} else {
				//end met
			}
		} else if (Application.loadedLevel == 5) {
			if (target != null) {
				targetPos = target.transform.position;
				transform.LookAt (target);
				transform.RotateAround (transform.position, transform.up, 90);
			} else {
				//end condition met
			}
		} else if (Application.loadedLevel == 9) {
			if (num == 0) {
				targetPos = target.transform.position;
				transform.LookAt (target);
				transform.RotateAround (transform.position, transform.up, 90);
			} else if (num == 1) {
				targetPos = target2.transform.position;
				transform.LookAt (target2);
				transform.RotateAround (transform.position, transform.up, 90);
			} else if (num == 2) {
				targetPos = target3.transform.position;
				transform.LookAt (target3);
				transform.RotateAround (transform.position, transform.up, 90);
			}else if (num == 3) {
				targetPos = target4.transform.position;
				transform.LookAt (target4);
				transform.RotateAround (transform.position, transform.up, 90);
			} else {
				//end condition met
			}
		}
	}
}
