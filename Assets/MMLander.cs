using UnityEngine;
using System.Collections;

public class MMLander : MonoBehaviour {
	
	public float turnSmoothing = 15f;   // A smoothing value for turning the player.
	public float speedDampTime = 0.1f;  // The damping for the speed parameter
	public Texture2D texture;
	public float v;
	public float h;
	public bool landed;
	public GameObject hut;
	public int score;
	public GameObject arrow;
	public Point pt;
	public Material checkpt;
	public float impactVel;
	//GameObject go;
	
	// Use this for initialization
	void Start ()
	{
		h = 0;
		v = 0;
		landed = false;
		//go = GameObject.CreatePrimitive(PrimitiveType.Cube);
		//go.renderer.material.mainTexture = Resources.Load<Texture2D>("ggd");

		//DontDestroyOnLoad (gameObject);
	}
	
	/*
	void OnGUI () {
		if (GUI.Button (new Rect (10,10, 200, 100), Resources.Load<Texture2D>("ggd"))) {
			print ("you clicked the icon");
		}
		
		if (GUI.Button (new Rect (10,110, 100, 20), "This is text")) {
			print ("you clicked the text button");
		}
	}
*/
	
	// Update is called once per frame
	void Update ()
	{
		#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
		float h = SBRemote.GetAxis ("Seebright_Horizontal");
		float v = SBRemote.GetAxis ("Seebright_Vertical");
		#endif
		//Debug.Log (rigidbody.velocity);
		
		//MovementManagement(h, v);
		
		if (Input.GetKey (KeyCode.UpArrow))
			;
		
		if (Input.GetKey (KeyCode.DownArrow))
			;
		if (Input.GetKey (KeyCode.W) || v > 0) {
			//transform.position += new Vector3 (-0.2f,0,0);
			transform.RotateAround (transform.position, transform.right, Time.deltaTime * 40);
		}
		if (Input.GetKey (KeyCode.S) || v < 0){
			//transform.position += new Vector3 (0.2f,0,0);
			transform.RotateAround (transform.position, -transform.right, Time.deltaTime * 40);
		}
		if (Input.GetKey (KeyCode.A) || h < 0){
			//transform.position += new Vector3 (0.2f,0,0);
			transform.RotateAround (transform.position, transform.forward, Time.deltaTime * 40);
		}
		if (Input.GetKey (KeyCode.D) || h > 0){
			//transform.position += new Vector3 (0.2f,0,0);
			transform.RotateAround (transform.position, -transform.forward, Time.deltaTime * 40);
		}
		if (Input.GetKey (KeyCode.J) || h > 0){
			//Application.LoadLevel ("Level 1");
		}
		if (Input.GetKey (KeyCode.L) || h > 0){
			Application.LoadLevel ("Level 1");
		}
		if (Input.GetKey (KeyCode.Mouse0) || Input.GetKey (KeyCode.LeftArrow)){
			transform.RotateAround (transform.position, -transform.up, Time.deltaTime * 40);
			//transform.RotateAround (transform.position, -transform.forward, Time.deltaTime * 40);
		}
		if (Input.GetKey (KeyCode.Mouse1) || Input.GetKey (KeyCode.RightArrow)){
			//transform.position += new Vector3 (0.2f,0,0);
			transform.RotateAround (transform.position, transform.up, Time.deltaTime * 40);
		}
		if (Input.GetKey (KeyCode.Space)) {
			rigidbody.AddForce(transform.up * 40);
			rigidbody.useGravity = true;
			rigidbody.isKinematic = false;
			//Physics.gravity = Vector3(0, 10, 0);
		}
		
		if (Input.GetKey (KeyCode.X)){
			//transform.position += new Vector3 (0.2f,0,0);
			transform.RotateAround (transform.position, transform.right, Time.deltaTime * 250);
		}
		if (Input.GetKey (KeyCode.C)){
			//transform.position += new Vector3 (0.2f,0,0);
			rigidbody.AddForce(transform.up * 150);
		}
		
	}
	
	void MovementManagement (float horizontal, float vertical)
	{
		
		// If there is some axis input...
		if (horizontal != 0f || vertical != 0f) {
			// ... set the players rotation and set the speed parameter to 5.5f.
			Rotating (horizontal, vertical);
		}
	}
	
	void Rotating (float horizontal, float vertical)
	{
		// Create a new vector of the horizontal and vertical inputs.
		Vector3 targetDirection = new Vector3 (horizontal, 0f, vertical);
		
		// Create a rotation based on this new vector assuming that up is the global y axis.
		Quaternion targetRotation = Quaternion.LookRotation (targetDirection, Vector3.up);
		
		// Create a rotation that is an increment closer to the target rotation from the player's rotation.
		Quaternion newRotation = Quaternion.Lerp (rigidbody.rotation, targetRotation, turnSmoothing * Time.deltaTime);
		
		// Change the players rotation to this new rotation.
		rigidbody.MoveRotation (newRotation);
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Border") {
			Application.LoadLevel ("Level Select");
		}
		if(other.tag == "CubeLevelSelectRestart") {
			Application.LoadLevel ("Level Select");
		}
	}

	void OnCollisionEnter(Collision Collision) {
		if (Collision.gameObject.tag == "Cube1") {
			Application.LoadLevel ("Level 1");
			
		} else if (Collision.gameObject.tag == "Cube2") {
			Application.LoadLevel ("Level 2");
		} else if (Collision.gameObject.tag == "Cube3") {
			Application.LoadLevel ("Level 3");
		} else if (Collision.gameObject.tag == "Cube4") {
			Application.LoadLevel ("Level 4");
		} else if (Collision.gameObject.tag == "Cube5") {
			Application.LoadLevel ("Level 5");
		} else if (Collision.gameObject.tag == "Cube6") {
			Application.LoadLevel ("Level 6");
		}
		if (Collision.gameObject.tag == "CubeRestart") {
			Application.LoadLevel ("Level Select");
		}
		if(Collision.gameObject.tag == "CubeQuit") {
			Application.Quit ();
			}
		if(Collision.gameObject.tag == "CubeMainMenu") {
			Application.LoadLevel ("Main Menu");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "LandingPad") {
			landed = true;
			other.renderer.material = checkpt;
			impactVel = 0f;
			score =+ 1;
		}
	}
}