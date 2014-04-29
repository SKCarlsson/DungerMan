using UnityEngine;
using System.Collections;

public class ProjectileWarriorNormalScript : Warrior {

	// Use this for initialization
	void Start () {
		Invoke("SelfDestruct", 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SelfDestruct()
	{
		Destroy(gameObject);
	}

	void OnCollisionExit(Collision other)
	{
		Destroy(gameObject);
		if(other.collider.tag =="Posh")
		{
			other.collider.GetComponent<Enemy>().takeDamage(75);
		}
	}
}
