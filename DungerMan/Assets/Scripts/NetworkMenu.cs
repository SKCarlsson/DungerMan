using UnityEngine;
using System.Collections;

public class NetworkMenu : MonoBehaviour {

	public string connectionIP 	= "127.0.0.1";
	public int portNumber		= 8632; // Set to something ridiculously high so its not allready taken

	private bool connected		= false;
	private void OnConnectedToServer()
	{

		// A client has just connected
		connected = true;
	}

	private void OnServerInitialized()
	{

		// The server has initialized
		connected = true;
	}

	private void OnDisconnectedFromServer()
	{
		// The connection has been lost, or disconnected
		connected = false;
	}

	private void OnGUI()
	{
		if(!connected)
		{
			connectionIP = GUILayout.TextField(connectionIP, GUILayout.Width(800), GUILayout.Height(100));
			int.TryParse (GUILayout.TextField(portNumber.ToString(), GUILayout.Width(800), GUILayout.Height(100)), out portNumber);

			if (GUILayout.Button ("Connect", GUILayout.Width(800), GUILayout.Height(100))){
			Network.Connect(connectionIP, portNumber);
			}
			if (GUILayout.Button ("Host", GUILayout.Width(800), GUILayout.Height(100))){
				Network.InitializeServer(4, portNumber, true); //Number of people who can ask to join the server at any given time (So not the total number of connections)
			}
		}
		else{
			GUILayout.Label ("Connections: " + Network.connections.Length.ToString());
		}

	}
}

/*Nice network functions to know
 * 1. OnDisconnectedFromServer
 * 2. OnPlayerDisconnected
 * 3. OnConnectedToServer
 * 4. OnServerInitialized
 * 5. Network.Connect
 * 6. Network.InitializeServer
 */