using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {
	GameObject posh;
	GameObject brah;
	GameObject player;
	int enemyCount;

	// Use this for initialization
	void Start () {


		Vector3 brahPos = transform.position; // copy to an auxiliary variable...
		brahPos.y = 1.0f; // modify the component you want in the variable...
		brahPos.x = Random.Range (-10.0f, 10.0f);
		brahPos.z = Random.Range (-10.0f, 10.0f);

		brah = Instantiate(Resources.Load("Brah")) as GameObject; 
		brah.transform.position = brahPos; // and save the modified value 


		// coordinates for the player 
		Vector3 playerPos = transform.position; // copy to an auxiliary variable...
		playerPos.y = 1.0f; // modify the component you want in the variable...
		playerPos.x = 5.0f;
		playerPos.z = 5.0f;
		
		// instantiation of the player
		player = Instantiate(Resources.Load("Player")) as GameObject; 
		player.transform.position = playerPos; // and save the modified value 



	}
	
	// Update is called once per frame
	void Update () {

		enemyCount = GameObject.FindGameObjectsWithTag("Posh").Length;

		if (enemyCount < 5) {
			
			Vector3 poshPos = transform.position; // copy to an auxiliary variable...
			poshPos.y = 1.0f; // modify the component you want in the variable...
			poshPos.x = Random.Range (-10.0f, 10.0f);
			poshPos.z = Random.Range (-10.0f, 10.0f);
			
			posh = Instantiate(Resources.Load("Posh")) as GameObject; 
			posh.transform.position = poshPos; // and save the modified value 



				}

	
	}
}
