using UnityEngine;
using System.Collections;

public class ProjectileWarriorSpecialScript : Warrior {
	
	// Use this for initialization
	void Start () {
		Invoke("SelfDestruct", 1f);
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
			other.collider.GetComponent<Enemy>().Health -= 100;
		}
	}
}
