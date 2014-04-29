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
	public int Mana;

	//


	// Use this for initialization
	void Start () {

		Instantiate((GameObject)Resources.Load ("Posh"), new Vector3(5, 1, 5), this.transform.rotation);

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
		Network.Destroy (gameObject);
		
	}

	


	//Check in Abutton whether or not the boolean is true or false, if it is true, execute SpecialAttack
	public abstract void SpecialAttackA ();
	public abstract void SpecialAttackB ();




}
