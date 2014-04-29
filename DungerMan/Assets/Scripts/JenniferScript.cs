using UnityEngine;
using System.Collections;

public class JenniferScript : Enemy {
	
	public override void ability ()
	{
		Debug.Log ("hello");
		
	}
	
	// Use this for initialization
	void Start () {
		
		ss = GameObject.Find ("Score(Clone)").GetComponent<ScoreScript>();
		
		players = GameObject.FindGameObjectsWithTag("Player"); // puts the gameobjects with the player tag into the array

		agent = GetComponent<NavMeshAgent>();
		
		
		// assigns values to the variables of this enemy:
		Health = 40;
		Damage = 15;
		Speed = 3.5f;
		AttackRange = 6;
		AttackSpeed = 2;
		SeeRange = 1000;
		canAttack = false;
		enemyPoint = 2;

		// sets the speed, as this is defined by the nav mesh agent:
		agent.speed = Speed;
		
	}
	
	// Update is called once per frame
	public void Update () 
	{
		// if player 1 is in the game, the dist variable is set to the distance between the enemy and the player
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

		// runs the autoattack function from the enemy class
		autoAttack ();

		if (canAttack) {
			// runs the attack function from the enemy class, if the enemy is close enough to attack
			Attack();
		}
		
	}
}
