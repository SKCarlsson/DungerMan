using UnityEngine;
using System.Collections;

public class Warrior : PlayerScript1 {
	private AudioSource hitWarrior;

	void Start () {

		hitWarrior = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip myHitWarrior;
		myHitWarrior = (AudioClip)Resources.Load ("Sounds/Warrior Sound");
		hitWarrior.clip = myHitWarrior;

		aButtonAction = GameObject.Find ("AButton").GetComponent<AButton> ();
		bButtonAction = GameObject.Find ("BButton").GetComponent<BButton> ();

		playerHealth = 200;
		AttackSpeed = 1f;
		SpecialAttackSpeed = 5f;

		//Energy - Rage
		Mana = 0;
		StartCoroutine("Regen");


	}
	
	// Update is called once per frame
	void Update () {

		if((aButtonAction.touch && buttonWaitA)){
			animation.Play("WarriorAtk");
			//animBool = true;
			StartCoroutine("buttonwaita");
			Network.Instantiate((GameObject)Resources.Load("ProjectileWarriorNormal"), transform.position + transform.forward*3.5f, transform.rotation,0);
			hitWarrior.Play();
			if (Mana >= 75){
				Mana = 100;
			} else {
				Mana += 25;
			}


		}
		//animBool = false;
		if(bButtonAction.touch == true && buttonWaitB){

			if (Mana >= 75){
				//animBool = true;
				animation.Play("WarriorAtk");
				StartCoroutine("buttonwaitb");
				Network.Instantiate((GameObject)Resources.Load("ProjectileWarriorSpecial"), transform.position + transform.forward*6f, transform.rotation,0);
				Mana -= 75;
			} else {
				Debug.Log ("Not enough rage!");
			}
		}

		//Regen
		if (playerHealth>= 200){
			playerHealth = 200;
		}
		if (playerHealth<= 0){
			playerHealth = 0;
		}

	}

	IEnumerator Regen(){
		bool regen = true;
		while (regen){
			yield return new WaitForSeconds(0.5f);
			playerHealth += 10;
		}
	}

	/*public override void SpecialAttackA () 
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
	}*/
	// used to make some cooldown time for the button
	IEnumerator buttonwaita(){
		buttonWaitA = false;
		yield return new WaitForSeconds(AttackSpeed);
		buttonWaitA = true;
	}

	// used to make some cooldown time for the button
	IEnumerator buttonwaitb(){
		buttonWaitB = false;
		yield return new WaitForSeconds(SpecialAttackSpeed);
		buttonWaitB = true;
	}

		

}

