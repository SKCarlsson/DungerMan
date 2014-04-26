using UnityEngine;
using System.Collections;

public class Warrior : PlayerScript1 {


	void Start () {

		aButtonAction = GameObject.Find ("AButton").GetComponent<AButton> ();
		bButtonAction = GameObject.Find ("BButton").GetComponent<BButton> ();


		Damage = 50;
		playerHealth = 200;
	}
	
	// Update is called once per frame
	void Update () {
		print (aButtonAction.touch);

		if(aButtonAction.touch && buttonWaitA){
			StartCoroutine("buttonwaita");
			enemyTakeDamage ();
		}
		if(bButtonAction.touch == true && buttonWaitB){
			print("DONE");
			SpecialAttackB();
		}

		raycast ();

		takeDamage ();

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

