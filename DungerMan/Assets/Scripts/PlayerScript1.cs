using UnityEngine;
using System.Collections;

public abstract class PlayerScript1 : MonoBehaviour {

	public int playerHealth;
	protected int Damage;
	protected int Speed;
	protected int AttackRange;
	protected int SeeRange;
	protected int AttackSpeed;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {


	}


	protected void takeDamage()
	{
		
		if (playerHealth <= 0) {
			die();
		}
		
	}

	protected void die()
	{
		Destroy (gameObject);
		
	}


}
