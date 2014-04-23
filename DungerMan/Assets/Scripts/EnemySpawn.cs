using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	GameObject posh;
	GameObject brah;

	GameObject player1;
	GameObject player2;

	public Warrior wa;
	public Wizard wi;

	int enemyCount;


	// Use this for initialization
	void Start () {

		// coordinates for player 1
		Vector3 player1Pos = transform.position; // copy to an auxiliary variable...
		player1Pos.y = 1.5f; // modify the component you want in the variable...
		player1Pos.x = 5.0f;
		player1Pos.z = 5.0f;
		
		// instantiation of player 1
		player1 = Instantiate(Resources.Load("Player 1")) as GameObject; 
		player1.transform.position = player1Pos; // and save the modified value 
		
		// adds the warrior script to the player1 gameobject
		player1.AddComponent ("Warrior");
		
		player1.renderer.material = Resources.Load("Warrior", typeof(Material)) as Material;
		


		// coordinates for player 2
		Vector3 player2Pos = transform.position; // copy to an auxiliary variable...
		player2Pos.y = 1.5f; // modify the component you want in the variable...
		player2Pos.x = 10.0f;
		player2Pos.z = 10.0f;


		// instantiation of player 2
		player2 = Instantiate(Resources.Load("Player 2")) as GameObject; 
		player2.transform.position = player2Pos; // and save the modified value 

		// adds the Wizard script to the player2 gameobject
		player2.AddComponent ("Wizard");

		player2.renderer.material = Resources.Load("Wizard", typeof(Material)) as Material;

	

	}
	
	// Update is called once per frame
	void Update () {

		enemyCount = GameObject.FindGameObjectsWithTag("Posh").Length;

		if (enemyCount < 5) {
			
			Vector3 poshPos = transform.position; // copy to an auxiliary variable...
			poshPos.y = 10.0f; // modify the component you want in the variable...
			poshPos.x = Random.Range (-10.0f, 10.0f);
			poshPos.z = Random.Range (-10.0f, 10.0f);
			
			posh = Instantiate(Resources.Load("Posh")) as GameObject; 
			posh.transform.position = poshPos; // and save the modified value 



				}

	
	}
}
