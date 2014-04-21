using UnityEngine;
using System.Collections;

public class PoshScript : Enemy {


	PlayerScript cc;

	public override void ability ()
	{
		Debug.Log ("hello");

	}

	// Use this for initialization
	void Start () {
		cc = GameObject.Find ("Player(Clone)").GetComponent<PlayerScript>();
		player = GameObject.Find ("Player(Clone)");
		agent = GetComponent<NavMeshAgent>();

		Health = 100;
		Damage = 30;
		Speed = 50;
		AttackRange = 2;
		AttackSpeed = 1;
		SeeRange = 5;
		canAttack = false;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		dist = Vector3.Distance(this.transform.position, player.transform.position);
		autoAttack ();

		//print (canAttack);


		if (canAttack) {
			//cc.pHealth -= 10;
			EnemyAttack(ref cc.pHealth);
			
		}


		//print (dist);
		//print ("posh: "+Health);
	
	}

	void OnCollisionEnter(Collision col)
	{
		// if the player collides with the key, following triggers:
		if (col.gameObject.name == "Player(Clone)") 
		{
			takeDamage(50);

		}
		
	}



	IEnumerator diee(){
		yield return new WaitForSeconds(5);
		die();
	}
	
}
