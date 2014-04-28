using UnityEngine;
using System.Collections;

public class ProjectileWarriorNormalScript : Warrior {

	// Use this for initialization
	void Start () {
		Invoke("SelfDestruct", 2f);
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
			other.collider.GetComponent<Enemy>().Health -= 50;
			Destroy(gameObject);
		}
		Debug.Log(other.collider.GetComponent<Enemy>().Health);
	}
}
