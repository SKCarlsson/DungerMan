using UnityEngine;
using System.Collections;

public class Warrior : PlayerScript1 {

	// Use this for initialization
	void Start () {

		playerHealth = 200;
	
	}
	
	// Update is called once per frame
	void Update () {

		raycast ();

		takeDamage ();

		//print ("warrior: "+playerHealth);
	
	}



}
