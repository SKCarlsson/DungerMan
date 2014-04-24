using UnityEngine;
using System.Collections;

public class Wizard : PlayerScript1 {

	// Use this for initialization
	void Start () {

		playerHealth = 150;
	
	}
	
	// Update is called once per frame
	void Update () {

		takeDamage ();

		//print ("wizard: " + playerHealth);
	
	}

	public override void SpecialAttackA () 
	{
	
	}
	public override void SpecialAttackB () 
	{
		
	}
}
