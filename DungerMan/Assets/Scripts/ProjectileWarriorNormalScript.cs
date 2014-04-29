using UnityEngine;
using System.Collections;

public class ProjectileWarriorNormalScript : Warrior {

	// Use this for initialization
	void Start () {
		Invoke("SelfDestruct", 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SelfDestruct()
	{
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag =="Posh")
		{
			other.collider.GetComponent<Enemy>().takeDamage(75);
			Destroy(gameObject);
		}
	}
}
