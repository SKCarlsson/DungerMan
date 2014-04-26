using UnityEngine;
using System.Collections;

public abstract class PlayerScript1 : MonoBehaviour {

	public int playerHealth;
	public int Damage;
	protected int Speed;
	protected int AttackRange;
	protected int SeeRange;
	protected int AttackSpeed;
	protected RaycastHit hitinfo;
	protected Enemy cc;
	
	protected AButton aButtonAction;
	protected BButton bButtonAction;
	
	protected bool buttonWaitA = true;
	protected bool buttonWaitB = true;

	//Other scripts
	public AButton AButtonScript;

	//Energy
	protected int Mana;


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
		Physics.Raycast (this.transform.position, fwd, out hitinfo, 10);
		Debug.DrawRay (this.transform.position, fwd,Color.green, 10);
	}

	protected void enemyTakeDamage(){
		print ("HIT THE BUTTON");
		cc.Health -=Damage;
	}

	//Check in Abutton whether or not the boolean is true or false, if it is true, execute SpecialAttack
	public abstract void SpecialAttackA ();
	public abstract void SpecialAttackB ();




}
