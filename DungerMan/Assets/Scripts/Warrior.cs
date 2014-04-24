using UnityEngine;
using System.Collections;

public class Warrior : PlayerScript1 {

	public AButton aButtonAction;
	public BButton bButtonAction;
	public bool buttonWaitA = true;
	public bool buttonWaitB = true;
	//public bool aButtonAttack;





	void Start () {

		aButtonAction = GameObject.Find ("AButton").GetComponent<AButton> ();
		bButtonAction = GameObject.Find ("BButton").GetComponent<BButton> ();
		playerHealth = 200;





	
	}
	
	// Update is called once per frame
	void Update () {

		raycast ();
		//print(aButtonAction.touch);
		takeDamage ();
		SpecialAttackA ();
		SpecialAttackB ();
		//print ("warrior: "+playerHealth);
	
	}
	public override void SpecialAttackA () 
	{

		if(aButtonAction.touch == true && buttonWaitA){
			StartCoroutine("buttonwaita");
		playerHealth += 20;
		Debug.Log ("ITS WORKING!!" + playerHealth);
		}



	}
	IEnumerator buttonwaita(){
		buttonWaitA = false;
		yield return new WaitForSeconds(5);
		buttonWaitA = true;
	}

	public override void SpecialAttackB () 
	{
		
		if(bButtonAction.touch == true && buttonWaitB){
			StartCoroutine("buttonwaitb");
			playerHealth += 20;
			Debug.Log ("ITS WORKING!!" + playerHealth);
		}
		
		
		
	}
	IEnumerator buttonwaitb(){
		buttonWaitB = false;
		yield return new WaitForSeconds(5);
		buttonWaitB = true;
	}



}
