using UnityEngine;
using System.Collections;

public class CoreHealth : MonoBehaviour {
	public Material hpMax;
	public Material hpHalf;
	public Material hpLow;
	public int hp;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		explosion.transform.localScale = new Vector3(100, 100, 100);
		renderer.material = hpMax;
		hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
		if (hp == 60) {
			renderer.material = hpHalf;
		}
		if (hp == 30) {
			renderer.material = hpLow;
		}
		if (hp <= 0) {
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject, 1f);

		}
	}
	void OnCollisionEnter(Collision collision){
		ContactPoint contact = collision.contacts [0];
		if (contact.otherCollider.tag == "Wrecking") {
			if(contact.otherCollider.GetComponent<MoveBox>().canHit){
				//Debug.Log ("HitCore");
				hp -= 10;
			}
			//collision.gameObject.rigidbody.velocity = new Vector3(-collision.gameObject.rigidbody.velocity.x*2, -collision.gameObject.rigidbody.velocity.y*2, -collision.gameObject.rigidbody.velocity.z*2);
		}
	}
}
