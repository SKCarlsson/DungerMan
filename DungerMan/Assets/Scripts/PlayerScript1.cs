using UnityEngine;
using System.Collections;

public abstract class PlayerScript1 : MonoBehaviour {

	public int playerHealth;
	protected int Speed;
	protected float AttackSpeed;
	protected float SpecialAttackSpeed;
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

	//Animation bool
	public bool animBool;

	//Regen
	public int regenTime = 1;
	public int regenAmount = 1;


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

}
