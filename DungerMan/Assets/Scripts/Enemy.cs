using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

		protected PlayerScript1 cc;

		protected GameObject player;
		protected GameObject player2;

		protected GameObject playerNum;// variable used to switch between the two player gameobjects

		protected NavMeshAgent agent;

		public int Health;
		protected int Damage;
		protected float Speed;
		protected int AttackRange;
		protected int SeeRange;
		protected int AttackSpeed;
		
		private float distance; // variable used to switch between the two dist variables
		
		protected float dist;// distance between player 1 and the enemy

		protected float dist2;// distance between player 2 and the enemy
		protected bool canAttack = false;
		protected bool haveWaited = true;

		public abstract void ability ();
		//protected PlayerScript cc = GameObject.Find ("Player(Clone)").GetComponent<PlayerScript>();
	
	// Use this for initialization
	void Start () {

		//cc = GameObject.Find ("Player 1(Clone)").GetComponent<PlayerScript1>();

		//player = GameObject.Find ("Cube");


	}

	// Update is called once per frame
	void Update (){

	}

	protected void autoAttack()
		{
		// checks if distance between player 1 and the enemy is bigger than the distance between player2 and the enemy:
		if(dist>dist2){
			// if this is true, the distance variable gets assigned the distance between player2 and the enemy
			distance = dist2;
			// and the playerNum variable gets the gameobject of player2
			playerNum = player2;
			}
		else {
			// else it must be player 1, which is closest:
				distance = dist;
				playerNum = player;
			}
		// makes the enemy go to the player which is closest:
		if (distance < SeeRange && distance > AttackRange) {
						agent.SetDestination (playerNum.transform.position);
						canAttack = false;
				} else if (distance <= AttackRange) {
						agent.SetDestination (this.transform.position);	
						canAttack = true;
				} else
						canAttack = false;
		}

	protected void Attack()
	{
		if (haveWaited) {
			StartCoroutine("reload");
				cc.playerHealth -= Damage;
				}
	}

	protected void takeDamage()
	{
	
		if (Health <= 0) {
			die();
				}

	}

	protected void die()
	{
		Destroy (gameObject);

		}

	IEnumerator reload(){
		haveWaited = false;
		yield return new WaitForSeconds(AttackSpeed);
		haveWaited = true;
		
	}


}
