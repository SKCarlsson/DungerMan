using UnityEngine;
using System.Collections;

public class PoshScript : Enemy {
	//private NavMeshAgent agent;
	//GameObject player;
	float dist = 0;
	

	public override void ability ()
	{
		Debug.Log ("hello");

	}

	// Use this for initialization
	void Start () {
		// finds the cube(aka the player)
		//player = GameObject.Find ("Cube");
		// navmesh something
		//agent = GetComponent<NavMeshAgent>();


		PoshScript Spice = new PoshScript ();

		Spice.Health = 100;
		Spice.Damage = 30;
		Spice.Speed = 50;
		Spice.AttackRange = 10;

		Spice.ability ();

	
	}
	
	// Update is called once per frame
	void Update () {
		//movement (Speed, AttackRange);
	
	}

	/*public void movement(int speed, int attackrange ){
		agent.speed = speed;

		dist = Vector2.Distance(this.transform.position, player.transform.position);
		
		print (dist);
		//RaycastHit hit;
		if(dist<attackrange){
			agent.SetDestination(player.transform.position);
		}


}*/
}
