using UnityEngine;
using System.Collections;

public class ProjectileWizardSpecialScript : Wizard {
	
	// Use this for initialization
	void Start () {
		//Running the selfDestruct function after 1.5 seconds
		
		Invoke("SelfDestruct", 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
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
		Debug.Log(other.collider.GetComponent<Enemy>().Health);
	}
}
