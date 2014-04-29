using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	string registeredGameName = "DungerManMLJS";
	bool isRefreshing = false;
	float refreshRequestLength = 3.0f;
	HostData[] hostData;
	private int waveCount = 0;
	private int enemyCount = 0;
	public Camera cam;
	private Camera camo;
	private Camera camo2;

	private GameObject posh;
	private GameObject player1 = null;
	private GameObject player2 = null;
	private Quaternion rotation;
	private Quaternion rotation2;

	bool player1init = false;
	bool player2init = false;






	void Awake(){
<<<<<<< HEAD
				rotation = cam.transform.rotation;
=======
		rotation = cam.transform.rotation;
>>>>>>> FETCH_HEAD
		}

	void Update(){
<<<<<<< HEAD
		
=======
		print (player1);
		print (player2);
=======
<<<<<<< HEAD
	void Update(){
=======
	
>>>>>>> FETCH_HEAD
>>>>>>> 101004dc78d29761e6f5cd98fd1f2d8707a8dd1c
>>>>>>> FETCH_HEAD

		if ( GameObject.Find ("Player 2(Clone)") != null ||  GameObject.Find ("Player 1(Clone)") != null && GameObject.Find ("Player 2(Clone)") != null ){
			EnemySpawn();
		}

	}

	void LateUpdate(){
<<<<<<< HEAD

=======
<<<<<<< HEAD
	
			
		camo2.transform.rotation = rotation;
=======
<<<<<<< HEAD
	
=======

>>>>>>> FETCH_HEAD
>>>>>>> 101004dc78d29761e6f5cd98fd1f2d8707a8dd1c
>>>>>>> FETCH_HEAD
		camo.transform.rotation = rotation;

		}

	private void StartServer()
	{
		Network.InitializeServer(16, 25001, false);
		MasterServer.RegisterHost(registeredGameName, "Dunger Man", "Mike Jens Simon Lars Dunger Man");
	}

	void OnServerInitialized()
	{
		Debug.Log ("Server is initialized!!!!!");
	}

	void OnMasterServerEvent(MasterServerEvent masterServerEvent)
	{
		if(masterServerEvent == MasterServerEvent.RegistrationSucceeded)
			Debug.Log("Registration Successfull");
	}

	public IEnumerator RefreshHostList()
	{
		Debug.Log ("Refreshing...");
		MasterServer.RequestHostList(registeredGameName);
		float timeStarted = Time.time;
		float timeEnd = Time.time + refreshRequestLength;

		while (Time.time < timeEnd)
		{
			hostData = MasterServer.PollHostList();
			yield return new WaitForEndOfFrame();
		}

		if(hostData == null || hostData.Length == 0)
			Debug.Log ("No active servers have been found.");
		else
			Debug.Log ("Wooot...  a server found?");
	}



	private void SpawnPlayer()
	{
<<<<<<< HEAD
=======
<<<<<<< HEAD
		if(GameObject.FindGameObjectsWithTag("Player").Length ==0) {
=======
<<<<<<< HEAD
>>>>>>> FETCH_HEAD
		if(GameObject.FindGameObjectsWithTag("Player").Length == 0) {
>>>>>>> 101004dc78d29761e6f5cd98fd1f2d8707a8dd1c
			print("player 1");
			Debug.Log ("Spawning Player....");
			
			Network.Instantiate (Resources.Load ("Player 1"), new Vector3 (7f, 1f, 5f), Quaternion.identity, 0);
			
			player1 = GameObject.Find ("Player 1(Clone)");
			// adds the warrior script to the player1 gameobject
			player1.AddComponent ("Warrior");
			
<<<<<<< HEAD
			player1.renderer.material = Resources.Load ("Warrior", typeof(Material)) as Material;
=======
			//player1.renderer.material = Resources.Load ("Warrior", typeof(Material)) as Material;

			camo = Instantiate (cam, new Vector3 (7, 21, 5), Quaternion.Euler (90, 0, 0)) as Camera;
			
			camo.transform.parent = player1.transform;
		}
		else{

		Debug.Log("Spawning Player....");
>>>>>>> 101004dc78d29761e6f5cd98fd1f2d8707a8dd1c

<<<<<<< HEAD
			camo = Instantiate (cam, new Vector3 (7, 21, 5), Quaternion.Euler (90, 0, 0)) as Camera;
			
			camo.transform.parent = player1.transform;
		
		}
=======
		Network.Instantiate (Resources.Load ("Player 1"), new Vector3 (5f, 1f, 5f), Quaternion.identity, 0);


		else  {
			print("player 2");
						Network.Instantiate (Resources.Load ("Player 2"), new Vector3 (5f, 1f, 5f), Quaternion.identity, 0);
			
						player2 = GameObject.Find ("Player 2(Clone)");
						// adds the warrior script to the player1 gameobject
<<<<<<< HEAD

=======
<<<<<<< HEAD
<<<<<<< HEAD
						player2.AddComponent ("Warrior");
			
						player2.renderer.material = Resources.Load ("Warrior", typeof(Material)) as Material;
=======
>>>>>>> 101004dc78d29761e6f5cd98fd1f2d8707a8dd1c
=======
>>>>>>> FETCH_HEAD
						player1.AddComponent ("Warrior");


						player2.AddComponent ("Warrior");
			

						//player2.renderer.material = Resources.Load ("Warrior", typeof(Material)) as Material;
						
						camo = Instantiate (cam, new Vector3 (5, 21, 5), Quaternion.Euler (90, 0, 0)) as Camera;
			
						camo.transform.parent = player2.transform;
			
				}
<<<<<<< HEAD
		
=======
=======
					
	/* Code for instantiating sprites as GameObjects
		//How to instantiate a sprite in the form of a gameobject
		public Sprite sprite;
		
		void Start()
		{
			GameObject go = new GameObject("Test");
			SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
			renderer.sprite = sprite;
		}*/

					
		camo = Instantiate(cam, new Vector3(5, 21, 5), Quaternion.Euler(180, 0, 0)) as Camera;
>>>>>>> FETCH_HEAD
						
<<<<<<< HEAD
						
						camo2 = Instantiate (cam, new Vector3 (5, 21, 5), Quaternion.Euler (90, 0, 0)) as Camera;
			
						camo2.transform.parent = player2.transform;
			
				}
=======
						camo.transform.parent = player1.transform;
>>>>>>> FETCH_HEAD
>>>>>>> 101004dc78d29761e6f5cd98fd1f2d8707a8dd1c

>>>>>>> FETCH_HEAD

	}

	private void SpawnPlayer2()
	{
<<<<<<< HEAD

				if (GameObject.FindGameObjectsWithTag ("Player").Length == 0) {
=======
<<<<<<< HEAD
		if(GameObject.FindGameObjectsWithTag("Player").Length ==0) {
=======
<<<<<<< HEAD
		if(GameObject.FindGameObjectsWithTag("Player").Length  == 0) {
>>>>>>> FETCH_HEAD
			
						Network.Instantiate (Resources.Load ("Player 1"), new Vector3 (7f, 1f, 5f), Quaternion.identity, 0);
			
						player1 = GameObject.Find ("Player 1(Clone)");
						// adds the warrior script to the player1 gameobject
						player1.AddComponent ("Wizard");
			
						//player1.renderer.material = Resources.Load ("Wizard", typeof(Material)) as Material;
<<<<<<< HEAD

						Network.Instantiate (Resources.Load ("Player 2"), new Vector3 (7f, 1f, 5f), Quaternion.identity, 0);

			
						player2 = GameObject.Find ("Player 2(Clone)");
						// adds the warrior script to the player1 gameobject
						player2.AddComponent ("Wizard");
			

=======
=======
			Network.Instantiate (Resources.Load ("Player 2"), new Vector3 (7f, 1f, 5f), Quaternion.identity, 0);
>>>>>>> FETCH_HEAD
>>>>>>> 101004dc78d29761e6f5cd98fd1f2d8707a8dd1c
			
						Network.Instantiate (Resources.Load ("Player 2"), new Vector3 (7f, 1f, 5f), Quaternion.identity, 0);
			
<<<<<<< HEAD
						player2 = GameObject.Find ("Player 2(Clone)");
						// adds the warrior script to the player1 gameobject
						player2.AddComponent ("Wizard");
=======
<<<<<<< HEAD
>>>>>>> FETCH_HEAD
						camo = Instantiate (cam, new Vector3 (7, 21, 5), Quaternion.Euler (90, 0, 0)) as Camera;
			
						camo.transform.parent = player1.transform;
			
				} else {
						Network.Instantiate (Resources.Load ("Player 2"), new Vector3 (5f, 1f, 5f), Quaternion.identity, 0);
			
						player2 = GameObject.Find ("Player 2(Clone)");
						// adds the warrior script to the player1 gameobject
						player2.AddComponent ("Wizard");
			
						//player2.renderer.material = Resources.Load ("Wizard", typeof(Material)) as Material;


						camo = Instantiate (cam, new Vector3 (5, 21, 5), Quaternion.Euler (90, 0, 0)) as Camera;
		
						camo.transform.parent = player2.transform;
<<<<<<< HEAD

=======
	
				}
=======
			player2.renderer.material = Resources.Load ("Wizard", typeof(Material)) as Material;
>>>>>>> 101004dc78d29761e6f5cd98fd1f2d8707a8dd1c
			
						player2.renderer.material = Resources.Load ("Wizard", typeof(Material)) as Material;
			
			
						camo2 = Instantiate (cam, new Vector3 (7, 21, 5), Quaternion.Euler (90, 0, 0)) as Camera;
			
						camo2.transform.parent = player2.transform;
			
				} else {
						Network.Instantiate (Resources.Load ("Player 1"), new Vector3 (5f, 1f, 5f), Quaternion.identity, 0);
			
						player1 = GameObject.Find ("Player 1(Clone)");
						// adds the warrior script to the player1 gameobject
						player1.AddComponent ("Wizard");
			
						player1.renderer.material = Resources.Load ("Wizard", typeof(Material)) as Material;


<<<<<<< HEAD
						camo = Instantiate (cam, new Vector3 (5, 21, 5), Quaternion.Euler (90, 0, 0)) as Camera;
		
						camo.transform.parent = player1.transform;
	
				}
=======
>>>>>>> FETCH_HEAD
>>>>>>> 101004dc78d29761e6f5cd98fd1f2d8707a8dd1c
>>>>>>> FETCH_HEAD
			
				}
		}

	private void EnemySpawn(){

		enemyCount = GameObject.FindGameObjectsWithTag ("Posh").Length;


		if (enemyCount <= 0 && waveCount >= 0 && waveCount < 5) {
			print ("spawn1");
						Network.Instantiate (Resources.Load ("Posh"), new Vector3 (-10f, 1f, -10f), Quaternion.identity, 0);
						Network.Instantiate (Resources.Load ("Posh"), new Vector3 (10f, 1f, -10f), Quaternion.identity, 0);
						Network.Instantiate (Resources.Load ("Posh"), new Vector3 (-10f, 1f, 10f), Quaternion.identity, 0);
						Network.Instantiate (Resources.Load ("Posh"), new Vector3 (10f, 1f, 10f), Quaternion.identity, 0);
			waveCount +=1;	
			} 
		else if (enemyCount <= 0 && waveCount >= 5 && waveCount < 10) {
			print ("spawn2");
						Network.Instantiate (Resources.Load ("Posh"), new Vector3 (-10f, 1f, -10f), Quaternion.identity, 0);
						Network.Instantiate (Resources.Load ("Posh"), new Vector3 (10f, 1f, -10f), Quaternion.identity, 0);
						Network.Instantiate (Resources.Load ("Posh"), new Vector3 (-10f, 1f, 10f), Quaternion.identity, 0);
						Network.Instantiate (Resources.Load ("Posh"), new Vector3 (10f, 1f, 10f), Quaternion.identity, 0);
			waveCount +=1;
		}

		}

	void OnPlayerDisconnected(NetworkPlayer player)
	{
		Debug.Log("Player disconnected from: " + player.ipAddress + ":" + player.port);
		Network.RemoveRPCs(player);
		Network.DestroyPlayerObjects(player);
	}

	void OnApplicationQuit()
	{
		if(Network.isServer)
		{
			Network.Disconnect(200);
			MasterServer.UnregisterHost();
		}

		if (Network.isClient)
			Network.Disconnect(200);
	}


	public void OnGUI()
	{
		if (Network.isServer)
			GUILayout.Label ("Running as a server.");
		else if (Network.isClient)
			GUILayout.Label ("Running as a client.");

		if (Network.isServer && player1init == false)
		{
			GUI.Box(new Rect(Screen.width/2-250,Screen.height/2-350,500,160),"Choose Role:");
			if(GUI.Button(new Rect(Screen.width/2-250,Screen.height/2-100,500,160),"Warrior")){
				SpawnPlayer();
				player1init = true;
			}
			if(GUI.Button(new Rect(Screen.width/2-250,Screen.height/2+80,500,160),"Wizzard")){
				SpawnPlayer2();
				player1init = true;
			}
		}

		if (Network.isClient && player2init == false) {

						

			GUI.Box (new Rect (Screen.width / 2 - 250, Screen.height / 2 - 350, 500, 160), "Choose Role:");
			if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height / 2 - 100, 500, 160), "Warrior")) {
				SpawnPlayer ();
				EnemySpawn ();
				player2init = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - 250, Screen.height / 2 + 80, 500, 160), "Wizzard")) {
				SpawnPlayer2 ();
				EnemySpawn ();
				player2init = true;
			}
						
		}
			
		if(!Network.isServer && !Network.isClient)
		{
			GUI.Box(new Rect(Screen.width/2-600,Screen.height/2-350,500,160),"Host/Refresh Servers");
			if(GUI.Button(new Rect(Screen.width/2-600,Screen.height/2-100,500,160),"Start New Server"))
			{
				//Start server function here
				StartServer();
			}
			if(GUI.Button(new Rect(Screen.width/2-600,Screen.height/2+80,500,160), "Refresh Server List"))
			{
			//Refresh Server List Function Here
			StartCoroutine("RefreshHostList");
			}

			if(hostData != null)
			{
				for(int i = 0; i<hostData.Length; i++)
				{
					if(GUI.Button(new Rect(Screen.width/2+100,Screen.height/2-100,500,160), hostData[i].gameName))
					{
						Debug.Log ("Trying to connect");
						Network.Connect(hostData[i]);
					}
				}
			}
		}
	}

}

