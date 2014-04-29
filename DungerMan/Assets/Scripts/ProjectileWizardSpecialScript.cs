using UnityEngine;
using System.Collections;

public class ProjectileWizardSpecialScript : Wizard {
	
	// Use this for initialization
	void Start () {
		Invoke("SelfDestruct", 1.5f);
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
			other.collider.GetComponent<Enemy>().takeDamage(100);
		}
		Debug.Log(other.collider.GetComponent<Enemy>().Health);
	}
}
