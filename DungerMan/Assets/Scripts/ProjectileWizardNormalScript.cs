using UnityEngine;
using System.Collections;

public class ProjectileWizardNormalScript : Wizard {
	
	// Use this for initialization
	void Start () {
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
	
	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag =="Posh")
		{
			other.collider.GetComponent<Enemy>().takeDamage(40);
			Destroy(gameObject);
		}
		Debug.Log(other.collider.GetComponent<Enemy>().Health);
	}
}
