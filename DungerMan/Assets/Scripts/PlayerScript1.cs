using UnityEngine;
using System.Collections;

public abstract class PlayerScript1 : MonoBehaviour {

	public int playerHealth;
	public int Damage;
	protected int Speed;
	protected int AttackRange;
	protected int SeeRange;
	protected int AttackSpeed;

	//Other scripts
	public AButton AButtonScript;

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

	protected void raycast(){
		Vector3 fwd = this.transform.TransformDirection(Vector3.forward);
		//if (Physics.Raycast(this.transform.position, fwd, 10))
		//print("There is something in front of the object!");
	}


	//Check in Abutton whether or not the boolean is true or false, if it is true, execute SpecialAttack
	public abstract void SpecialAttackA ();
	public abstract void SpecialAttackB ();




}
