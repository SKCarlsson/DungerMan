using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	string registeredGameName = "DungerManMLJS";
	bool isRefreshing = false;
	float refreshRequestLength = 3.0f;
	HostData[] hostData;

	private void StartServer()
	{
		Network.InitializeServer(16, 25001, false);
		MasterServer.RegisterHost(registeredGameName, "Dunger Man", "Mike Jens Simon Lars Dunger Man");
	}

	void OnServerInitialized()
	{
		Debug.Log ("Server is initialized!!!!!");
		SpawnPlayer();
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

		Network.Instantiate (Resources.Load ("Player 1"), new Vector3(1f,5f,5f), Quaternion.identity, 0);
		
		// adds the warrior script to the player1 gameobject
		/*player1.AddComponent ("Warrior");
		
		player1.renderer.material = Resources.Load("Warrior", typeof(Material)) as Material;

		//Network.Instantiate (Resources.Load ("Player1"), new Vector3(0f,2.5f,0f), Quaternion.identity, 0);

		//Assigning Player 2's transform
	}

	/*private void SpawnPlayer2()
	{
		player2 = Network.Instantiate (Resources.Load ("Player 2"), new Vector3(1f,10f,10f), Quaternion.identity, 0); 
		
		// adds the Wizard script to the player2 gameobject
		player2.AddComponent ("Wizard");
		
		player2.renderer.material = Resources.Load("Wizard", typeof(Material)) as Material;
*/
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

		if (Network.isClient)
		{
			if(GUI.Button(new Rect(25,25,125,30),"Spawn")){
				SpawnPlayer();
				return;
			}
		}
			
		if(!Network.isServer && !Network.isClient)
		{
			if(GUI.Button(new Rect(25,25,250,80),"Start New Server"))
			{
				//Start server function here
				StartServer();
			}
			if(GUI.Button(new Rect(25,115,250,80), "Refresh Server List"))
			{
			//Refresh Server List Function Here
			StartCoroutine("RefreshHostList");
			}

			if(hostData != null)
			{
				for(int i = 0; i<hostData.Length; i++)
				{
					if(GUI.Button(new Rect(Screen.width/2, 65f + (30f * i), 300f, 80f), hostData[i].gameName))
					{
						Debug.Log ("Trying to connect");
						Network.Connect(hostData[i]);
					}
				}
			}
		}
	}
}
