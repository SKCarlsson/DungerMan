using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	string registeredGameName = "DungerManMLJS";
	bool isRefreshing = false;
	float refreshRequestLength = 3.0f;
	HostData[] hostData;
	private int enemyCount = 0;
	public Camera cam;
	private Camera camo;

	private GameObject posh;
	private GameObject player1 = null;
	private GameObject player2 =null;
	private Quaternion rotation;

	bool player1init = false;
	bool player2init = false;

	public Sprite sprite;


	void Awake(){
		rotation = cam.transform.rotation;


		}

	void LateUpdate(){

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
		Debug.Log("Spawning Player....");

		Network.Instantiate (Resources.Load ("Player 1"), new Vector3 (5f, 1f, 5f), Quaternion.identity, 0);

						player1 = GameObject.Find ("Player 1(Clone)");
						// adds the warrior script to the player1 gameobject
						player1.AddComponent ("Warrior");

		player1.renderer.material = Resources.Load ("Warrior", typeof(Material)) as Material;
			
					
	/* Code for instantiating sprites as GameObjects
		//How to instantiate a sprite in the form of a gameobject
		public Sprite sprite;
		
		void Start()
		{
			GameObject go = new GameObject("Test");
			SpriteRenderer renderer = go.AddComponent<SpriteRenderer>();
			renderer.sprite = sprite;
		}
	}*/
					
		camo = Instantiate(cam, new Vector3(5, 21, 5), Quaternion.Euler(180, 0, 0)) as Camera;
						
						camo.transform.parent = player1.transform;
			

	}
	

	private void SpawnPlayer2()
	{
			Network.Instantiate (Resources.Load ("Player 2"), new Vector3 (7f, 1f, 5f), Quaternion.identity, 0);
			
			player2 = GameObject.Find ("Player 2(Clone)");
			// adds the warrior script to the player1 gameobject
			player2.AddComponent ("Wizard");
			
			player2.renderer.material = Resources.Load ("Wizard", typeof(Material)) as Material;
			
			camo = Instantiate(cam, new Vector3(7, 21, 5), Quaternion.Euler(90, 0, 0)) as Camera;
		
			camo.transform.parent = player2.transform;


			
	}

	private void EnemySpawn(){


			while (enemyCount < 5) {


			Network.Instantiate (Resources.Load ("ZombieEnemy"), new Vector3 ( Random.Range (-10.0f, 10.0f),1f, Random.Range (-10.0f, 10.0f)), Quaternion.identity, 0);
			enemyCount = GameObject.FindGameObjectsWithTag ("ZombieEnemy").Length;
			/*	Vector3 poshPos = transform.position; // copy to an auxiliary variable...
			poshPos.y = 1.0f; // modify the component you want in the variable...
			poshPos.x = Random.Range (-10.0f, 10.0f);
			poshPos.z = Random.Range (-10.0f, 10.0f);
			
			posh = Instantiate(Resources.Load("Posh")) as GameObject; 
			posh.transform.position = poshPos; // and save the modified value*/ 


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

