﻿using UnityEngine;
using System.Collections;

public class ProjectileWarriorSpecialScript : Warrior {
	
	// Use this for initialization
	void Start () {
		//Running the selfDestruct function after 1 second
		Invoke("SelfDestruct", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	//Destroying the gameobject, removing it from the scene
	
	void SelfDestruct()
	{
		Destroy(gameObject);
	}
	//When the projectile collides with an enemy run this
	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag =="Posh")
		{
			//Run a function to subtract damage from the enemy's health
			
			other.collider.GetComponent<Enemy>().takeDamage(100);
		}
	}
}
