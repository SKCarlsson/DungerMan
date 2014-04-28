using UnityEngine;
using System.Collections;

public class PoshScript : Enemy {

	public override void ability ()
	{
		Debug.Log ("hello");

	}

	// Use this for initialization
	void Start () {

		players = GameObject.FindGameObjectsWithTag("Player");

		// gives all the variables from the enemy class some values:
		player = GameObject.Find ("Player 1(Clone)");
		player2 = GameObject.Find ("Player 2(Clone)");
		agent = GetComponent<NavMeshAgent>();


		Health = 100;
		Damage = 30;
		Speed = 3.5f;
		AttackRange = 2;
		AttackSpeed = 1;
		SeeRange = 5;
		canAttack = false;


		// sets the speed, as this is defined by the nav mesh agent:
		agent.speed = Speed;

	}
	
	// Update is called once per frame
	void Update () 
	{

		takeDamage();


		if (players [0] != null) {
			dist = Vector3.Distance (this.transform.position, players[0].transform.position);
			if (playerNum == players[0]) {
				// sets the cc to be the Playerscript of player 2
				cc = players[0].GetComponent<PlayerScript1> ();
			}		
		}
		if (players[1] != null) {
			// updates the dist2(distance between player2 and enemy) variable for use in the enemy class.
			dist2 = Vector3.Distance (this.transform.position, players[1].transform.position);
			if (playerNum == players[1]) {
				// sets the cc to be the Playerscript of player 2
				cc = players[1].GetComponent<PlayerScript1> ();
			}
		}







		/*if (player != null) {
			// updates the dist(distance between player1 and enemy) variable for use in the enemy class.
						dist = Vector3.Distance (this.transform.position, player.transform.position);
		if (playerNum == player) {
				// sets the cc to be the Playerscript of player 2
						cc = GameObject.Find ("Player 1(Clone)").GetComponent<PlayerScript1> ();
						}
				} 
		if (player2 != null) {
			// updates the dist2(distance between player2 and enemy) variable for use in the enemy class.
						dist2 = Vector3.Distance (this.transform.position, player2.transform.position);
		if (playerNum == player2) {
				// sets the cc to be the Playerscript of player 2
						cc = GameObject.Find ("Player 2(Clone)").GetComponent<PlayerScript1> ();
						}
				}*/


		// runs the autoattack function from the enemy class
		autoAttack ();


		if (canAttack) {
			// runs the attack function from the enemy class, if the enemy is close enough to attack
			Attack();
		}
	
	}

	void OnCollisionEnter(Collision col)
	{
		// if the player collides with the key, following triggers:
		if (col.gameObject.name == "Player 1(Clone)") 
		{

		}



	}


	IEnumerator diee(){
		yield return new WaitForSeconds(5);
		die();
	}
	
}
