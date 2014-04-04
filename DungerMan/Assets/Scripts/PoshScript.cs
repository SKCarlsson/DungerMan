using UnityEngine;
using System.Collections;

public class PoshScript : Enemy {
	

	public override void ability ()
	{
		Debug.Log ("hello");

	}

	// Use this for initialization
	void Start () {

		PoshScript Spice = new PoshScript ();

		Spice.health = 100;
		Spice.damage = 30;
		Spice.speed = 50;
		Spice.attackRange = 10;

		Spice.ability ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
