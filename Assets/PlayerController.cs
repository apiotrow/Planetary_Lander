using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public int LEVEL_1;
	public int LEVEL_2;
	public int LEVEL_3;

	public bool landed;
	public bool canCrash;
	public bool[] building;
	public GameObject hut;
	public float h;
	public float v;
	public int score;
	public GameObject arrow;
	public Point pt;
	public Vector3 collVec;
	public float impactVel;
	public float fuelCap;
	public float fuelCurr;
	public Material checkpt;

	public Vector3 storedVel;
	public LandingPad lp;
	public Transform loc;

	public bool boundaryWarning;

	//Pause Menu
	public GameObject pauser;
	public Pausation ps;
	public string currentMenu;
	private bool display = false;

	public float ImpactVel {
		get {
			return impactVel;
		}
	}
	
	public float health;
	
	public float Health {
		get {
			return health;
		}
	}

	public CoreHealth tower;
	public bool watchingTowerExplosion;
	public bool towerExploded;
	public Vector3 towPos;
	public Vector3 dirFling;
	public bool youDied;

	public int maxPlayerAltitude;
	public int maxPlayerSpeed;
	public BallBox ballBox;
	public bool makeBoxLower;
	public Transform realBallBox;
	public int numBalls;
	public bool carryingBalls;
	public SmoothFollowCSharp smoothFollow;
	public bool inCameraSequence;
	public GameObject mainCamera;
	public bool sittingOnBallLZ;
	public Vector3 LZPos;
	public float ballGameTimer;

	public bool boxConnected;

	//Ball pit 1 stuff
	public Transform ball;
	public Transform LZBallPit;
	//holds the repo doors so we can change their
	//kinematic status
	public BallRepoDoor door1;
	public BallRepoDoor door2;
	
	//Ball pit 2 stuff
	public Transform ball2;
	public Transform LZBallPit2;
	//holds the repo doors so we can change their
	//kinematic status
	public BallRepoDoor repo2door1;
	public BallRepoDoor repo2door2;
	
	//Ball pit 3 stuff
	public Transform ball3;
	public Transform LZBallPit3;
	//holds the repo doors so we can change their
	//kinematic status
	public BallRepoDoor repo3door1;
	public BallRepoDoor repo3door2;
	
	//Ball pit 4 stuff
	public Transform ball4;
	public Transform LZBallPit4;
	//holds the repo doors so we can change their
	//kinematic status
	public BallRepoDoor repo4door1;
	public BallRepoDoor repo4door2;
	
	public ReceptacleFloor recep;
	public float ballsPerSec;
	public int prevNumBallsInside;

	public bool completedLevel;
	public Texture finalGuy;

	public float maxLowAngle;
	public float maxHighAngle;

	public int numBoxesUp;
	public GameObject nBox1;
	public GameObject nBox2;
	public GameObject nBox3;
	public GameObject nBox4;
	public Transform tar1spawn;
	public Transform tar2spawn;
	public Transform tar3spawn;
	public Transform tar4spawn;

	// Use this for initialization
	void Start ()
	{
		numBoxesUp = 0;
		building = new bool[4];
		fuelCap = 300.0f;
		fuelCurr = fuelCap;
		arrow = GameObject.FindGameObjectWithTag ("Arrow");
		pt = arrow.GetComponent<Point> ();
		pauser = GameObject.FindGameObjectWithTag ("Pauser");
		ps = pauser.GetComponent<Pausation> ();
		h = 0;
		v = 0;
		landed = false;
		impactVel = 100;
		health = 100;
		canCrash = true;
		boundaryWarning = false;

		//maxPlayerAltitude = 100;
		//if (Application.loadedLevel == 2) {
			//maxPlayerAltitude = 250;
		//}

		maxPlayerSpeed = 140;
		makeBoxLower = false;
		carryingBalls = false;
		numBalls = 0;


		if (Application.loadedLevel == 6) {
			maxLowAngle = 100;
			maxHighAngle = 250;
		} else{
			maxLowAngle = 80;
			maxHighAngle = 280;
		}

		
		//make balls non-moving
		if (Application.loadedLevel == 6) {
			ball.rigidbody.isKinematic = true;
			foreach (Transform child in ball.transform) {
				child.rigidbody.isKinematic = true;
			}
		}
		
		inCameraSequence = false;
		
		//so both ball repo doors will be in the closed
		//position initially
		door1.rigidbody.isKinematic = true;
		door2.rigidbody.isKinematic = true;
		repo2door1.rigidbody.isKinematic = true;
		repo2door2.rigidbody.isKinematic = true;
		repo3door1.rigidbody.isKinematic = true;
		repo3door2.rigidbody.isKinematic = true;
		repo4door1.rigidbody.isKinematic = true;
		repo4door2.rigidbody.isKinematic = true;
		
		ballGameTimer = 0.0f;
		sittingOnBallLZ = false;
		ballsPerSec = 0;
		prevNumBallsInside = 0;

		watchingTowerExplosion = false;
		towerExploded = false;
		completedLevel = false;
		youDied = false;
		boxConnected = false;
	}

	//Displays values for playtesting/debugging purposes
	//May also invlude in final build
	void OnGUI ()
	{
		/*
		if (GUI.Button (new Rect (10,10, 200, 100), Resources.Load<Texture2D>("ggd"))) {
			//print ("you clicked the icon");
		}
		*/
		

		string healthText = "Health: " + (Mathf.Floor (health)).ToString ();
		if (GUI.Button (new Rect (Screen.width - 100, 0, 100, 30), healthText)) {

			
			//print (impactVel);
		}

		string fuelText = "Fuel: " + (Mathf.Floor (fuelCurr)).ToString ();
		if (GUI.Button (new Rect (Screen.width - 100, 30, 100, 30), fuelText)) {
		}

		if (Application.loadedLevel == 2) {
			string landedText = "Landed on: " + (Mathf.Floor (score)).ToString ();
			if (GUI.Button (new Rect (Screen.width - 100, 60, 100, 30), landedText)) {
			}

			string objText = "FOLLOW THE ARROW AND LAND ON THE PADS! "/* + (Mathf.Floor (score)).ToString ()*/;
			if (GUI.Button (new Rect ((Screen.width / 2) - 100, 0, 400, 30), objText)) {
				
			}
		}else if (Application.loadedLevel == 5) {
			string crushText = "DESTROY THE EVIL TOWER! "/* + (Mathf.Floor (score)).ToString ()*/;
			if (GUI.Button (new Rect ((Screen.width / 2) - 100, 0, 200, 30), crushText)) {

			}
			
			string coreHealth = "Tower Health: " + (Mathf.Floor (tower.hp)).ToString ();
			if (GUI.Button (new Rect (Screen.width - 120, 60, 120, 30), coreHealth)) {
			}
		}

		/*else if (Application.loadedLevel == 2) {
			string delivText = "Delivered: " + (Mathf.Floor (score)).ToString ();
			if (GUI.Button (new Rect (Screen.width - 100, 60, 100, 30), delivText)) {
			}
		}
		*/


		//stuff for the ball carrying level
		if (carryingBalls) {
			string ballText = "Rocks in Pit: " + (numBalls.ToString ());
			string timerText = "Time: " + ((Mathf.Floor (ballGameTimer)).ToString ());
			string bpsText = "Balls-per-second: " + ((ballsPerSec).ToString ());
			string objectiveText = "GET 40 ROCKS IN THE PIT!";
			if (GUI.Button (new Rect (Screen.width - 300, 0, 200, 30), ballText)) {
			}
			/*
			if (GUI.Button (new Rect (Screen.width - 300, 30, 200, 30), timerText)) {
			}
			*/
			/*
			if (GUI.Button (new Rect (Screen.width - 300, 70, 200, 30), bpsText)) {
			}
			*/
			if (GUI.Button (new Rect ((Screen.width / 2) - 100, 0, 200, 30), objectiveText)) {
			}
			
		}

		if (completedLevel) {
			//if(Application.loadedLevel == 2 || Application.loadedLevel == 3 ){
				string winText = "YOU WIN!";
				string winText2 = "GOOD JOB!";
				string winText3 = "I LOVE YOU!";
				if (GUI.Button (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 100, 200, 30), winText)) {
				}
				if (GUI.Button (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 70, 200, 30), winText2)) {
				}
				if (GUI.Button (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 40, 200, 30), winText3)) {
				}
			//}
		}


		if (youDied) {
				string dieText = "YOU DIED!";
				string winText2 = "GOOD JOB!";
				if (GUI.Button (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 80, 200, 30), dieText)) {
					
				}
				if (GUI.Button (new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 50, 200, 30), winText2)) {
				}

			//GUI.DrawTexture(new Rect ((Screen.width / 2) - 100, (Screen.height / 2) - 230, 150,  150), finalGuy);
		}

		if (Application.loadedLevel == 8) {
			GUI.Button (new Rect (Screen.width - 100, 60, 100, 30), "Checkpoint: " + (Mathf.Floor (score)).ToString ());

		}
		
		if(currentMenu == "Main")
			Main_Menu();
		if(currentMenu == "Controls")
			Main_Controls();

		if (display && ps.paused) {
			GUI.Box(new Rect((Screen.width / 2) - 100, (Screen.height / 3) + 10, 200, 30), "W - Tilt Forward (Pitch Up)");
			GUI.Box(new Rect((Screen.width / 2) - 300, (Screen.height / 2) - 50, 190, 30), "A - Tilt Left (Yaw Left)");
			GUI.Box(new Rect((Screen.width / 2) - 360, (Screen.height / 2) - 0, 250, 30), "Left Mouse Click - Tilt Left (Yaw Left)");
			GUI.Box(new Rect((Screen.width / 2) - 100, (Screen.height / 2) + 150, 200, 30), "S - Tilt Backward (Pitch Back)");
			GUI.Box(new Rect((Screen.width / 2) + 120, (Screen.height / 2) - 50, 190, 30), "D - Tilt Right (Yaw Right)");
			GUI.Box(new Rect((Screen.width / 2) + 120, (Screen.height / 2) - 0, 250, 30), "Right Mouse Click - Tilt Right (Yaw Right)");
			GUI.Box(new Rect((Screen.width / 2) - 360, (Screen.height / 2) + 50, 250, 30), "Left Arrow - Turn Left");
			GUI.Box(new Rect((Screen.width / 2) + 120, (Screen.height / 2) + 50, 250, 30), "Right Arrow - Turn Right");
			GUI.Box(new Rect(1200,190,170,30), "Space - Thrust");
			GUI.Box(new Rect(1200,220,170,30), "P - Pause Game");
			GUI.Box(new Rect(1200,250,170,30), "C - Super Thrust");
			GUI.Box(new Rect(1200,280,170,30), "X - Fast Flip");
		}
		
		if (boundaryWarning) {
			string warning = "Warning: Return to Mission";
			GUI.Button(new Rect((Screen.width / 2) - 100, (Screen.height / 3) - 50, 200, 50), warning);
		}
	}

	IEnumerator EndMissionWait (string level, float sec)
	{
		yield return new WaitForSeconds (sec);
		Application.LoadLevel ("Mission Accomplished");
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!ps.paused) {
			#if (UNITY_IPHONE || UNITY_ANDROID) && !UNITY_EDITOR
		float h = SBRemote.GetAxis ("Seebright_Horizontal");
		float v = SBRemote.GetAxis ("Seebright_Vertical");
			#endif

			//Death and mission-winning stuff
			if(Application.loadedLevel == 3 && score == 3){
				completedLevel = true;
				StartCoroutine (EndMissionWait ("Level Select", 3f));
			}
			if(Application.loadedLevel == 4 && score == 4){
				completedLevel = true;
				StartCoroutine (EndMissionWait ("Level Select", 3f));
			}

			if((Application.loadedLevel == 5) && tower.hp <= 0){
				completedLevel = true;
				StartCoroutine (EndMissionWait ("Level Select", 3f));
			}

			if((Application.loadedLevel == 6) && numBalls >= 40){
				completedLevel = true;
				StartCoroutine (EndMissionWait ("Level Select", 3f));
			}

			if(health <= 0 || fuelCurr == 0){
				youDied = true;
				finalGuy = (Texture2D)Resources.Load ("ggd");
				StartCoroutine (EndMissionWait ("Game Over", 3f));
			}


			//User-input
			if (Input.GetKey (KeyCode.UpArrow))
				;

			if (Input.GetKey (KeyCode.DownArrow))
				;
			if (Input.GetKey (KeyCode.W) || v > 0) {
				//transform.position += new Vector3 (-0.2f,0,0);
				transform.RotateAround (transform.position, transform.right, Time.deltaTime * 40);
			}
			if (Input.GetKey (KeyCode.S) || v < 0) {
				//transform.position += new Vector3 (0.2f,0,0);
				transform.RotateAround (transform.position, -transform.right, Time.deltaTime * 40);
			}
			if (Input.GetKey (KeyCode.A) || h < 0) {
				//transform.position += new Vector3 (0.2f,0,0);
				transform.RotateAround (transform.position, transform.forward, Time.deltaTime * 40);
			}
			if (Input.GetKey (KeyCode.D) || h > 0) {
				//transform.position += new Vector3 (0.2f,0,0);
				transform.RotateAround (transform.position, -transform.forward, Time.deltaTime * 40);
			}
			if (Input.GetKey (KeyCode.Mouse0) || Input.GetKey (KeyCode.LeftArrow)) {
				transform.RotateAround (transform.position, -transform.up, Time.deltaTime * 120);
				//transform.RotateAround (transform.position, -transform.forward, Time.deltaTime * 40);
			}
			if (Input.GetKey (KeyCode.Mouse1) || Input.GetKey (KeyCode.RightArrow)) {
				//transform.position += new Vector3 (0.2f,0,0);
				transform.RotateAround (transform.position, transform.up, Time.deltaTime * 120);
			}
			if ((Input.GetKey (KeyCode.Space)) && fuelCurr > 0) {

				fuelCurr -= .1f;

				//if (rigidbody.velocity.y < (maxPlayerSpeed - 5) && 
					//transform.position.y < maxPlayerAltitude) {
					
					rigidbody.AddForce (transform.up * 50);
				//}

				//RenderSettings.fogEndDistance = maxPlayerAltitude - transform.position.y;
			}



			if (Input.GetKey (KeyCode.X)) {
				//transform.position += new Vector3 (0.2f,0,0);
				transform.RotateAround (transform.position, transform.right, Time.deltaTime * 250);
			}
			if (Input.GetKey (KeyCode.C)) {
				//if(rigidbody.velocity.y < (maxPlayerSpeed - 5) && 
				   //transform.position.y < maxPlayerAltitude){
					
					rigidbody.AddForce (transform.up * 150);
				//}
			}
			if(Input.GetKey(KeyCode.L)){
				//Application.LoadLevel ("Level Select");
			}
			if(Input.GetKey(KeyCode.M)){
				//Application.LoadLevel ("Main Menu");
			}

			if(Input.GetKey(KeyCode.Alpha1)){
				//Application.LoadLevel ("Level 1");
			}
			if(Input.GetKey(KeyCode.Alpha2)){
				//Application.LoadLevel ("Level 3");
			}
			if(Input.GetKey(KeyCode.Alpha3)){
				//Application.LoadLevel ("Level 4");
			}


			storedVel = rigidbody.velocity;
			if (Input.GetKey (KeyCode.P)) {
				//Pauses Game
				//oredVel = rigidbody.velocity;
				StartCoroutine (PauseStart ());
				currentMenu = "Main";
				//currentMenu = "Level Select";

			}
			//toredVel = rigidbody.velocity;
		} else if (ps.paused) {
			if (Input.GetKeyDown (KeyCode.P)) {
				//UnPauses the game
				StartCoroutine (PauseWait ());
				currentMenu = null;

				/*ps.paused = false;
				rigidbody.useGravity = true;
				rigidbody.velocity = storedVel;*/
			}
		}

		
		//this code is a placeholder. the problem is that if the player
		//is past the height ceiling and can no longer accelerate, they
		//won't be able to go in the x or z directions either. they'll just
		//drift until they fall below the cieling, then can acclerate again.
		//What we really want is a downward acceleration that slowly
		//pushes the craft back down when they're past the cieling, and can 
		//negate any upward acceleration it is recieving
		/*
		if(transform.position.y >= maxPlayerAltitude){
			Debug.Log (transform.position.y);
			Vector3 f = rigidbody.velocity;
			f.y = 0;
			rigidbody.velocity = f;
			//f = transform.position;
			//f.y = maxPlayerAltitude;
			//transform.position = f;
		}   
		*/
		
		//calls to limitation functions
		fixRotation ();
		//hitCieling ();
		hitSpeedCap ();


		//Debug.Log (transform.position.y);




		 //Below this point is stuff for the ball level.
		 //It shouldn't affect operations in other levels
		 //due to boolean checks before every block of code




		//this code runs the camera sequence that allows us to watch the
		//ball repo drop its balls
		if (inCameraSequence) {
			
			//commented out because the C# version of SmoothFollow
			//isn't being used currently (JS version is less jittery)
			/*
			//move the camera out and up so we can see the balls
			//drop down
			if (smoothFollow.distance < 30f) {
				smoothFollow.distance += 0.1f;
			}
		
			if (smoothFollow.height < 50f) {
				smoothFollow.height += 0.1f;
			}
			*/
			
			//puts the camera outward so we get a scenic view
			//of the balls dropping
			mainCamera.transform.position = new Vector3 (transform.position.x + 50, 
			                                             transform.position.y + 50, 
			                                             transform.position.z + 20);
			mainCamera.transform.LookAt (transform.position);
			
		} else {
			//smoothFollow.distance = 20;
			//smoothFollow.height = 20;
		}

		if (Application.loadedLevel == 5) {
			if (tower.hp <= 0 && towerExploded == false) {
				if (watchingTowerExplosion == false) {
					dirFling = transform.position - tower.transform.position;
					towPos = tower.transform.position;
					watchingTowerExplosion = true;
					rigidbody.AddForce (-dirFling * rigidbody.velocity.y * 150);
					StartCoroutine (WaitForExplosion ());
				}

				//Debug.Log (transform.rotation.x);
				//transform.Rotate (Vector3(transform.rotation.x, transform.rotation.y + 2, transform.rotation.z));
				mainCamera.transform.LookAt (towPos);


			}
		}

		/*
		//lock camera so we can watch the tower explosion
		if (tower.hp <= 0 && inCameraSequence == true) {
			towerExploded = true;
			mainCamera.transform.position = new Vector3 (transform.position.x + 80, 
			                                             transform.position.y + 30, 
			                                             transform.position.z + 60);
			mainCamera.transform.LookAt (tower.transform.position);
		}
		*/
		
		/*
		if (makeBoxLower) {
			lowerBallBox ();
		}
		*/
		
		//to freeze player on the landing pad for some amount
		//of seconds
		
		if (sittingOnBallLZ == true) {
			
			Vector3 u = rigidbody.velocity;
			u.x = 0;
			u.y = 0;
			u.z = 0;
			rigidbody.velocity = u;
			
			transform.position = LZPos;
		}
		
		
		
		//counts the amount of balls that have ended up in the receptacle
		//each frame so we can disply them in the GUI
		if (carryingBalls) {
			
			//commented out because the C# version of SmoothFollow
			//isn't being used currently (JS version is less jittery)
			/*
			if (smoothFollow.distance > 20f)
				smoothFollow.distance -= 0.1f;
			
			if (smoothFollow.height > 20f)
				smoothFollow.height -= 0.1f;
				*/
			
			//start the timer for the ball game
			ballGameTimer += Time.deltaTime;
			
			numBalls = 0;
			
			numBalls = recep.numBallInside;
			
			if(numBalls > prevNumBallsInside){
				ballsPerSec = numBalls / ballGameTimer;
			}
			
			prevNumBallsInside = numBalls;
			
			//Debug.Log (numBalls);
		}

	}

	//This function deals with the player hitting an altitude we don't
	//want him/her to go above. Variable to modify the height is maxPlayerAltitude
	void hitCieling ()
	{
		
		float amountPastLimit = transform.position.y - maxPlayerAltitude;
		//When the player reached max altitude, the game send it back down
		if (transform.position.y > maxPlayerAltitude) {
			//Debug.Log (transform.position.y);
			Vector3 globalDown = new Vector3 (transform.position.x, transform.position.y - 300, transform.position.z);
			//Debug.DrawLine(transform.position, globalDown, Color.green, 2, false);
			Vector3 downDir = transform.position - globalDown;
			
			
			//This throws the craft in the -y position with a force equal to its
			//upward force. This helps make the cieling smooth.
			float smallDistance = 10;
			//if(amountPastLimit < smallDistance){
				//Debug.Log (rigidbody.velocity.y);
				//rigidbody.AddForce (-downDir * rigidbody.velocity.y * (2f));
			//}else{
			//Debug.Log(transform.position.y);
			
				rigidbody.AddForce (-downDir * rigidbody.velocity.y * (amountPastLimit / 50));
			//}
			
			
			/*
			if (rigidbody.velocity.y > 10) {
				rigidbody.AddForce (-downDir * rigidbody.velocity.y / 10);
			} else {
				rigidbody.AddForce (-downDir / 30);
			}
			*/
		}
	}
	
	//this function is for if the lander for some reason (impact with terrain
	//or moving object) gets flung at a high speed. because of the thrust cap,
	//the player wouldn't be able to thrust to slow itself down. this function
	//keeps that from happening.
	void hitSpeedCap(){
		//Debug.Log (rigidbody.velocity);
		//positive velocities
		if(rigidbody.velocity.y > maxPlayerSpeed){
			Vector3 v = rigidbody.velocity;
			v.y = maxPlayerSpeed;
			rigidbody.velocity = v;
		}
		
		if(rigidbody.velocity.x > maxPlayerSpeed){
			Vector3 v = rigidbody.velocity;
			v.x = maxPlayerSpeed;
			rigidbody.velocity = v;
		}
		
		if(rigidbody.velocity.z > maxPlayerSpeed){
			Vector3 v = rigidbody.velocity;
			v.z = maxPlayerSpeed;
			rigidbody.velocity = v;
		}
		
		//negative velocities
		if(rigidbody.velocity.y < -maxPlayerSpeed){
			Vector3 v = rigidbody.velocity;
			v.y = -maxPlayerSpeed;
			rigidbody.velocity = v;
		}
		
		if(rigidbody.velocity.x < -maxPlayerSpeed){
			Vector3 v = rigidbody.velocity;
			v.x = -maxPlayerSpeed;
			rigidbody.velocity = v;
		}
		
		if(rigidbody.velocity.z < -maxPlayerSpeed){
			Vector3 v = rigidbody.velocity;
			v.z = -maxPlayerSpeed;
			rigidbody.velocity = v;
		}
		
	}
	
	//this simply causes a pause of a specified amount of seconds
	//while we're watching the ball drop from the ball repo
	IEnumerator WaitForExplosion ()
	{

		yield return new WaitForSeconds (5f);
		towerExploded = true;
		
	}

	//this simply causes a pause of a specified amount of seconds
	//while we're watching the ball drop from the ball repo
	IEnumerator Wait ()
	{
		//so we can watch the balls fall
		yield return new WaitForSeconds (6f);
		inCameraSequence = false;
		smoothFollow.enabled = true;
		
	}
	
	IEnumerator BallLZWait ()
	{
		inCameraSequence = true;
		yield return new WaitForSeconds (3f);
		sittingOnBallLZ = false;
	}

	IEnumerator CanCrashWait ()
	{
		yield return new WaitForSeconds (1f);
		canCrash = true;
	}
	
	void lowerBallBox ()
	{
		//lerp the ball box toward the player
		transform.forward = ballBox.transform.forward;
		rigidbody.velocity = new Vector3 (0, 0, 0);

		Vector3 above = transform.position;


		ballBox.transform.position = Vector3.Lerp (ballBox.transform.position, above, Time.deltaTime / 2);


		//using the inCameraSequence bool to make sure we only set player
		//position once. if we try it repeatedly the camera will shake
		if(inCameraSequence == false)
			transform.position = LZPos;
		
		
		//so we can have the camera go into a zoom out sequence
		//so we can watch the balls fall
		inCameraSequence = true;
		smoothFollow.enabled = false;
		
		
		//coroutine to run camera sequence for some amount of seconds
		StartCoroutine (Wait ());

		if(ballBox.transform.position.y <= (transform.position.y + 10)){
			boxConnected = true;
		}
		
		//if the ball box has made contact with the player
		if (boxConnected == true) {
			//make the fake one that just lowered dissappear
			ballBox.renderer.enabled = false;
			ballBox.collider.enabled = false;
			foreach (Transform child in ballBox.transform) {
				child.renderer.enabled = false;
				child.collider.enabled = false;
			}


			door1.rigidbody.isKinematic = false;
			door2.rigidbody.isKinematic = false;
			
			//make the actual ball box appear
			realBallBox.renderer.enabled = true;
			realBallBox.collider.enabled = true;
			foreach (Transform child in realBallBox.transform) {
				child.renderer.enabled = true;
				child.collider.enabled = true;
			}
			

			
			//commented out because we're counting how many balls
			//we put in the receptable now, instead of how 
			//many we're carrying
			/*
			 * //count the number of balls we're carrying
			foreach (Transform child in ball.transform) {
				numBalls += 1;
			}
			*/
			
			//balls have to be non-moving initially or they'll fall through 
			//the bottom of the fake box for some reason
			//this makes them moveable and then sends them downward
			ball.rigidbody.isKinematic = false;
			foreach (Transform child in ball.transform) {
				child.rigidbody.isKinematic = false;
				child.rigidbody.velocity = new Vector3 (0, -1, 0);
			}
			
			//so we know to begin counting how many balls are lost
			carryingBalls = true;
			
			//so we don't continue coming to this routine
			makeBoxLower = false;
			
			//we're done with camera sequence. can move camera back
			//inCameraSequence = false;
			
		}
		
		
	}
	
	
	//This function makes the player rotate back to a more-or-less upright position
	//if their rotation becomes extreme. It is meant to prevent the player
	//from going upside down, which makes the camera screwy.
	void fixRotation ()
	{
		Vector3 start = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		
		if (transform.eulerAngles.z > maxLowAngle && transform.eulerAngles.z < 180) {
			Vector3 end = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, start.z - 1);
			transform.eulerAngles = end;
		} else if (transform.eulerAngles.z < maxHighAngle && transform.eulerAngles.z > 180) {
			Vector3 end = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, start.z + 1);
			transform.eulerAngles = end;
		}
		
		if (transform.eulerAngles.x > maxLowAngle && transform.eulerAngles.x < 180) {
			Vector3 end = new Vector3 (start.x - 1, transform.eulerAngles.y, transform.eulerAngles.z);
			transform.eulerAngles = end;
		} else if (transform.eulerAngles.x < maxHighAngle && transform.eulerAngles.x > 180) {
			Vector3 end = new Vector3 (start.x + 1, transform.eulerAngles.y, transform.eulerAngles.z);
			transform.eulerAngles = end;
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		//For when craft collides with terrain
		//Lowers health based on how quickly player
		//runs into terrain
		if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "asteroid") {
			collVec = collision.contacts [0].point - transform.position;
			impactVel = Vector3.Dot (collVec.normalized, rigidbody.velocity);
			//Debug.Log (impactVel);
			health -= Mathf.Sqrt (Mathf.Abs (impactVel));
		}
		if ((collision.gameObject.tag == "Shield" || collision.gameObject.tag == "Core") && canCrash) {
			health -= 5;
			canCrash = false;
			StartCoroutine(CanCrashWait());
		}

		if(collision.gameObject.tag == "CubeMissionAccomplished") {
			Application.LoadLevel ("Mission Accomplished");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		//landing on a pad
		if (other.tag == "LandingPad") {
			landed = true;
			other.renderer.material = checkpt;
			impactVel = 0f;
		}else if (other.tag == "Refuel") {
			//going through a refuel ring
			DestroyObject (other.gameObject);
			fuelCurr = fuelCap;
		} else if (other.tag == "LZBuilding") {
			//landing on the building pads (No implemented in level 1)
			other.renderer.material = checkpt;
			lp = other.gameObject.GetComponent<LandingPad> ();
			building [lp.num] = true;
		}else if (other.tag == "LZBallPit") {
			/*
			other.renderer.material = checkpt;
			other.isTrigger = false;
			//makeBoxLower = true;
			LZPos = other.gameObject.transform.position;
			DestroyObject (other.gameObject);
			//Debug.Log ("makeBoxLower: " + makeBoxLower);
			*/
			
			
			//using the inCameraSequence bool to make sure we only set player
			//position once. if we try it repeatedly the camera will shake
			
			
			
			//so we can have the camera go into a zoom out sequence
			//so we can watch the balls fall
			//inCameraSequence = true;
			//smoothFollow.enabled = false;
			
			
			//coroutine to run camera sequence for some amount of seconds
			StartCoroutine (Wait ());
			
			Vector3 u = rigidbody.velocity;
			u.x = 0;
			u.y = 0;
			u.z = 0;
			rigidbody.velocity = u;
			LZPos = other.gameObject.transform.position;
			LZPos.y += 5;
			//DestroyObject (other.gameObject);
			transform.position = LZPos;
			
			/*
			if(inCameraSequence == false)
				transform.position = LZPos;
				*/
			
			other.renderer.material = checkpt;
			other.isTrigger = false;
			
			sittingOnBallLZ = true;
			//will set the above boolean to false after 
			//some amount of seconds
			StartCoroutine (BallLZWait ());
			
			
			
			//so we know to begin counting how many balls are lost
			carryingBalls = true;
			
			ball.rigidbody.isKinematic = false;
			door1.rigidbody.isKinematic = false;
			door2.rigidbody.isKinematic = false;
			ball.rigidbody.velocity = new Vector3 (0, -1, 0);
			
			
			foreach (Transform child in ball.transform) {
				child.rigidbody.isKinematic = false;
				child.rigidbody.velocity = new Vector3 (0, -1, 0);
			}
			
		}else if (other.tag == "LZBallPit2") {
			//being lazy for now and having all the ball pit 2
			//stuff in here. should eventually have a function for this
			
			//coroutine to run camera sequence for some amount of seconds
			//StartCoroutine (Wait ());
			
			Vector3 u = rigidbody.velocity;
			u.x = 0;
			u.y = 0;
			u.z = 0;
			rigidbody.velocity = u;
			LZPos = other.gameObject.transform.position;
			LZPos.y += 5;
			//DestroyObject (other.gameObject);
			transform.position = LZPos;
			
			other.renderer.material = checkpt;
			other.isTrigger = false;
			
			//sittingOnBallLZ = true;
			//will set the above boolean to false after 
			//some amount of seconds
			//StartCoroutine (BallLZWait ());
			
			repo2door1.rigidbody.isKinematic = false;
			repo2door2.rigidbody.isKinematic = false;
			ball2.rigidbody.isKinematic = false;
			ball2.rigidbody.velocity = new Vector3 (0, -1, 0);
			
			foreach (Transform child in ball2.transform) {
				child.rigidbody.isKinematic = false;
				child.rigidbody.velocity = new Vector3 (0, -1, 0);
			}
			
			
			//makeBoxLower = true;
			
		}else if (other.tag == "LZBallPit3") {
			//being lazy for now and having all the ball pit 3
			//stuff in here. should eventually have a function for this
			
			
			//coroutine to run camera sequence for some amount of seconds
			//StartCoroutine (Wait ());
			
			Vector3 u = rigidbody.velocity;
			u.x = 0;
			u.y = 0;
			u.z = 0;
			rigidbody.velocity = u;
			LZPos = other.gameObject.transform.position;
			LZPos.y += 5;
			//DestroyObject (other.gameObject);
			transform.position = LZPos;
			
			other.renderer.material = checkpt;
			other.isTrigger = false;
			
			//sittingOnBallLZ = true;
			//will set the above boolean to false after 
			//some amount of seconds
			//StartCoroutine (BallLZWait ());
			
			repo3door1.rigidbody.isKinematic = false;
			repo3door2.rigidbody.isKinematic = false;
			ball3.rigidbody.isKinematic = false;
			ball3.rigidbody.velocity = new Vector3 (0, -1, 0);
			
			foreach (Transform child in ball3.transform) {
				child.rigidbody.isKinematic = false;
				child.rigidbody.velocity = new Vector3 (0, -1, 0);
			}
			
			//makeBoxLower = true;
			//Debug.Log ("makeBoxLower: " + makeBoxLower);
		}else if (other.tag == "LZBallPit4") {
			//being lazy for now and having all the ball pit 3
			//stuff in here. should eventually have a function for this
			
			//coroutine to run camera sequence for some amount of seconds
			//StartCoroutine (Wait ());
			
			Vector3 u = rigidbody.velocity;
			u.x = 0;
			u.y = 0;
			u.z = 0;
			rigidbody.velocity = u;
			LZPos = other.gameObject.transform.position;
			LZPos.y += 5;
			//DestroyObject (other.gameObject);
			transform.position = LZPos;
			
			other.renderer.material = checkpt;
			other.isTrigger = false;
			
			//sittingOnBallLZ = true;
			//will set the above boolean to false after 
			//some amount of seconds
			//StartCoroutine (BallLZWait ());
			
			repo4door1.rigidbody.isKinematic = false;
			repo4door2.rigidbody.isKinematic = false;
			ball4.rigidbody.isKinematic = false;
			ball4.rigidbody.velocity = new Vector3 (0, -1, 0);
			
			foreach (Transform child in ball4.transform) {
				child.rigidbody.isKinematic = false;
				child.rigidbody.velocity = new Vector3 (0, -1, 0);
			}
			
			//makeBoxLower = true;
			//Debug.Log ("makeBoxLower: " + makeBoxLower);
		}

		if (other.tag == "Bound") {
			boundaryWarning = false;
		}

	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "LandingPad" && landed) {
			//leaving the landing pad
			loc = other.transform;
			StartCoroutine (WaitBase (loc));
			DestroyObject (other.gameObject, 3f);
			landed = false; 
		}
		if (other.tag == "LZPU") {
			Destroy(other.gameObject);
			if(nBox1 != null && nBox1.transform.parent != transform && pt.num == 0){
				//pt.num = 0;
				numBoxesUp += 1;
				rigidbody.mass += 1;
				nBox1.transform.parent = transform;
				nBox1.transform.rotation = tar1spawn.rotation;
				nBox1.transform.position = tar1spawn.position - new Vector3(1.5f,0,3f);
				//nBox1.rigidbody.isKinematic = false;
				nBox1.rigidbody.useGravity = true;
			}
			if(nBox2 != null && nBox2.transform.parent != transform && pt.num == 1){
				//pt.num = 1;
				numBoxesUp += 1;
				rigidbody.mass += 1;
				nBox2.transform.parent = transform;
				nBox2.transform.rotation = tar1spawn.rotation;
				nBox2.transform.position = tar1spawn.position - new Vector3(1.5f,0,3f);
				//nBox1.rigidbody.isKinematic = false;
				nBox2.rigidbody.useGravity = true;
			}
			if(nBox3 != null && nBox3.transform.parent != transform && pt.num == 2){
				numBoxesUp += 1;
				rigidbody.mass += 1;
				nBox3.transform.parent = transform;
				nBox3.transform.rotation = tar1spawn.rotation;
				nBox3.transform.position = tar1spawn.position - new Vector3(1.5f,0,3f);
				//nBox1.rigidbody.isKinematic = false;
				nBox3.rigidbody.useGravity = true;
			}
			if(nBox4 != null && nBox4.transform.parent != transform && pt.num == 3){
				numBoxesUp += 1;
				rigidbody.mass += 1;
				nBox4.transform.parent = transform;
				nBox4.transform.rotation = tar1spawn.rotation;
				nBox4.transform.position = tar1spawn.position - new Vector3(1.5f,0,3f);
				//nBox1.rigidbody.isKinematic = false;
				nBox4.rigidbody.useGravity = true;
			}
		}
		if (other.tag == "LZDrop1" && rigidbody.mass >= 1.9f) {
			//Destroy (other.gameObject);
			if (nBox1.transform.parent == transform) {
				pt.num = 1;
				score = 1;
				numBoxesUp -= 1;
				rigidbody.mass -= 1;
				Destroy (nBox1);
				Destroy (other.gameObject);
			}
		}if (other.tag == "LZDrop2" && rigidbody.mass >= 1.9f) {
			if (nBox2.transform.parent == transform) {
				pt.num = 2;
				score = 2;
				numBoxesUp -= 1;
				rigidbody.mass -= 1;
				Destroy (nBox2);
				Destroy (other.gameObject);
			}
		}if (other.tag == "LZDrop3" && rigidbody.mass >= 1.9f) {
			if (nBox3.transform.parent == transform) {
				pt.num = 3;
				score = 3;
				numBoxesUp -= 1;
				rigidbody.mass -= 1;
				Destroy (nBox3);
				Destroy (other.gameObject);
			}
		}if (other.tag == "LZDrop4" && rigidbody.mass >= 1.9f) {
			if (nBox4.transform.parent == transform) {
				pt.num = 4;
				score = 4;
				numBoxesUp -= 1;
				rigidbody.mass -= 1;
				Destroy (nBox4);
				Destroy (other.gameObject);
			}
		}

		if (other.tag == "Bound") {
			boundaryWarning = true;
		} else if (other.tag == "Bound2") {
			Application.LoadLevel ("Game Over");
		}
	}


	IEnumerator WaitBase (Transform loc)
	{
		//spawn the base on top of the landing pad
		yield return new WaitForSeconds (1.5f);
		if (Application.loadedLevel == 3) {
			Instantiate (hut, loc.position, loc.rotation);
		}
		if (score == 0) {
			score = 1;
			pt.num = score;
		}else if (score == 1) {
			score = 2;
			pt.num = score;
		}else if (score == 2) {
			score = 3;
			pt.num = score;
		}else if (score == 3) {
			score = 4;
			pt.num = score;
		}
	}

	IEnumerator PauseWait ()
	{
		//delay on pause
		yield return new WaitForSeconds (.1f);
		ps.paused = false;
		rigidbody.useGravity = true;
		rigidbody.velocity = storedVel;
	}

	IEnumerator PauseStart ()
	{
		//delay on unpause
		yield return new WaitForSeconds (.1f);
		ps.paused = true;
		rigidbody.useGravity = false;
		rigidbody.velocity = new Vector3 (0, 0, 0);
	}

	public void NavigateTo(string nextmenu) {
		currentMenu = nextmenu;
	}

	public void Main_Menu() {
		GUI.Label((new Rect((Screen.width / 2) - 25f, (Screen.height / 15f), 200f, 30f)), "Paused");

		if(GUI.Button((new Rect((Screen.width / 2) - 100f, (Screen.height / 15f) + (Screen.height / 18f), 200f, 50f)), "Controls")) {
			//NavigateTo("Controls");
			display =! display;
		}

		if (GUI.Button((new Rect((Screen.width / 2) - 100f, (Screen.height / 15f) + 2f * (Screen.height / 18f), 200f, 50f)), "Level Select")) {
			Application.LoadLevel ("Level Select");

		}

		if (GUI.Button((new Rect((Screen.width / 2) - 100f, (Screen.height / 15f) + 3f * (Screen.height / 18f), 200f, 50f)), "Restart")) {
			if (Application.loadedLevel == 3){
				Application.LoadLevel ("Level 1");
			}
			if (Application.loadedLevel == 4){
				Application.LoadLevel ("Level 2");
			}
			if (Application.loadedLevel == 5){
				Application.LoadLevel ("Level 3"); 
			}
			if (Application.loadedLevel == 6){
				Application.LoadLevel ("Level 4");
			}
			if (Application.loadedLevel == 7){
				Application.LoadLevel ("Level 5");
			}
			if (Application.loadedLevel == 8){
				Application.LoadLevel ("Level 6");
			}
			
		}

		if (GUI.Button((new Rect((Screen.width / 2) - 100, (Screen.height / 15f) + 4f * (Screen.height / 18f), 200, 50)), "Quit")) {
			Application.Quit();
			
		}

	}
	
	public void Main_Controls() {
		GUI.Label(new Rect(10, 10, 200, 50), "Controls");

		if(GUI.Button(new Rect(400, 70, 200, 50), "Back")) {
			//NavigateTo("Main");
			//display = false;
		}
	}
}