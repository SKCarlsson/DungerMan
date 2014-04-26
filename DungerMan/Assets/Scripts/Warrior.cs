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
		print (aButtonAction.touch);

		if(aButtonAction.touch && buttonWaitA){
			if (hitinfo.transform.gameObject!= null) 
			{
				cc = hitinfo.transform.gameObject.GetComponent<Enemy> ();
				StartCoroutine("buttonwaita");
				enemyTakeDamage (0);
				Mana += 15;
				if (Mana > 100)
				{
					Mana = 100;
				}
			}

		}
		if(bButtonAction.touch == true && buttonWaitB){

			print("DONE");
			SpecialAttackB();
		}

		raycast ();

		//takeDamage ();


			if (hitinfo.transform.gameObject!= null && Mana >= 25) 
			{
				cc = hitinfo.transform.gameObject.GetComponent<Enemy> ();
				StartCoroutine("buttonwaitb");
				enemyTakeDamage (25);
				Mana -= 25;
			}		

		raycast ();
	
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

