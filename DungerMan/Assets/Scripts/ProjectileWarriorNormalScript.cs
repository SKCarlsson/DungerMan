using UnityEngine;
using System.Collections;

public class ProjectileWarriorNormalScript : Warrior {
	
	// Use this for initialization
	void Start () {
		//Running the selfDestruct function after 0.3 seconds
		Invoke("SelfDestruct", 0.3f);
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
		//If the enemy have the tag posh run this
		if(other.collider.tag =="Posh")
		{
			//Run a function to subtract damage from the enemy's health, and destroy the projectile afterwards
			other.collider.GetComponent<Enemy>().takeDamage(75);
			Destroy(gameObject);
		}
	}
}
