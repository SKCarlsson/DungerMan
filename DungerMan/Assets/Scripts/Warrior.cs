using UnityEngine;
using System.Collections;

public class Warrior : PlayerScript1 {

	void Start () {

		aButtonAction = GameObject.Find ("AButton").GetComponent<AButton> ();
		bButtonAction = GameObject.Find ("BButton").GetComponent<BButton> ();


		Damage = 50;
		playerHealth = 200;

		//Energy - Rage
		Mana = 0;
	}
	
	// Update is called once per frame
	void Update () {

		//Instantiate((GameObject)Resources.Load("ProjectileWarriorNormal"), transform.position + transform.forward*1.5f, transform.rotation);


		//print (aButtonAction.touch);
		//print (aButtonAction.touch);

		if((aButtonAction.touch && buttonWaitA)){

			StartCoroutine("buttonwaita");
			Instantiate((GameObject)Resources.Load("ProjectileWarriorNormal"), transform.position + transform.forward*1.5f, transform.rotation);
			if (Mana >= 75){
				Mana = 100;
			} else {
				Mana += 25;
			}


		}
		if(bButtonAction.touch == true && buttonWaitB){
			if (Mana >= 75){
				StartCoroutine("buttonwaitb");
				Instantiate((GameObject)Resources.Load("ProjectileWarriorSpecial"), transform.position + transform.forward*3f, transform.rotation);
				Mana -= 75;
			} else {
				Debug.Log ("Not enough rage!");
			}
		}



			


	}

	public override void SpecialAttackA () 
	{
		StartCoroutine("buttonwaita");
		playerHealth += 20;
		Debug.Log ("ITS WORKING!!" + playerHealth);	
	}

	public override void SpecialAttackB () 
	{
			StartCoroutine("buttonwaitb");
			playerHealth += 20;
			Debug.Log ("ITS WORKING!!" + playerHealth);	
	}

	IEnumerator buttonwaita(){
		buttonWaitA = false;
		yield return new WaitForSeconds(1);
		buttonWaitA = true;
	}


	IEnumerator buttonwaitb(){
		buttonWaitB = false;
		yield return new WaitForSeconds(5);
		buttonWaitB = true;
	}

		

}

