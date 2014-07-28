using UnityEngine;
using System.Collections;

public class BuildingBlock : MonoBehaviour {
	public int num;
	public GameObject player;
	public PlayerController pc;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		pc = player.GetComponent<PlayerController>();
		renderer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (pc.building [num]) {
			renderer.enabled = true;
		}
	
	}
}
