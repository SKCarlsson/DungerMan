using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

		protected GameObject player;

		protected NavMeshAgent agent;

		protected int Health;
		protected int Damage;
		protected int Speed;
		protected int AttackRange;
		protected int SeeRange;
		protected int AttackSpeed;
		protected float dist;
		protected bool canAttack = false;
		protected bool haveWaited = true;

		public abstract void ability ();
		//protected PlayerScript cc = GameObject.Find ("Player(Clone)").GetComponent<PlayerScript>();
	
	// Use this for initialization
	void Start () {



		//player = GameObject.Find ("Cube");


	}

	// Update is called once per frame
	void Update () {

	
	
	}

	protected void autoAttack()
		{

		if (dist < SeeRange && dist > AttackRange) {
						agent.SetDestination (player.transform.position);
						canAttack = false;
				} else if (dist <= AttackRange) {
						agent.SetDestination (this.transform.position);	
						canAttack = true;
				} else
						canAttack = false;
		}

	protected void EnemyAttack(ref int playerHealth)
	{
		if (haveWaited) {
			StartCoroutine("reload");
						playerHealth -= Damage;
				}
	}

	protected void takeDamage(int amount)
	{
		Health -= amount;

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
