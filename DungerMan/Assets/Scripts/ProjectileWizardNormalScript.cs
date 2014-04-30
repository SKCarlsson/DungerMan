using UnityEngine;
using System.Collections;

public class ProjectileWizardNormalScript : Wizard {
	
	// Use this for initialization
	void Start () {
		//Running the selfDestruct function after 3 seconds
		
		Invoke("SelfDestruct", 3f);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += transform.forward*1;
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
			//Run a function to subtract damage from the enemy's health, and destroy the projectile afterwards
			
			other.collider.GetComponent<Enemy>().takeDamage(40);
			Destroy(gameObject);
		}
		Debug.Log(other.collider.GetComponent<Enemy>().Health);
	}
}
