using UnityEngine;
using System.Collections;

public class BrahScript : Enemy{
	

	public override void ability ()
	{
		Debug.Log ("hello");
		
	}
	
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player(Clone)");
		agent = GetComponent<NavMeshAgent>();
		
		Health = 500;
		Damage = 30;
		Speed = 50;
		AttackRange = 2;
		SeeRange = 3;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		dist = Vector3.Distance(this.transform.position, player.transform.position);
		autoAttack ();
		//print (dist);
		//print ("brah: "+Health);
		
	}
	
	void OnCollisionEnter(Collision col)
	{
		// if the player collides with the key, following triggers:
		if (col.gameObject.name == "Player(Clone)") 
		{
			takeDamage(50);
			//die ();
		}
		
	}
	
	
	
	IEnumerator diee(){
		yield return new WaitForSeconds(5);
		die();
	}
}
