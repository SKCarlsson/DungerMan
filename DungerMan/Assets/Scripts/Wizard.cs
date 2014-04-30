using UnityEngine;
using System.Collections;

public class Wizard : PlayerScript1 {
	private AudioSource hitWarlock;
	private bool replenish = true;

	void Start () {
		hitWarlock = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip myHitWarlock;
		myHitWarlock = (AudioClip)Resources.Load ("Sounds/Warlock Sound");
		hitWarlock.clip = myHitWarlock;
		
		aButtonAction = GameObject.Find ("AButton").GetComponent<AButton> ();
		bButtonAction = GameObject.Find ("BButton").GetComponent<BButton> ();
		

		playerHealth = 100;
		AttackSpeed = 0.25f;
		SpecialAttackSpeed = 5f;
		
		//Energy - Rage
		Mana = 0;
		StartCoroutine("ReplenishMana");

		//Regen
		StartCoroutine("Regen");
	}
	
	// Update is called once per frame
	void Update () {

		takeDamage ();// checks if the player should be dead


		if((aButtonAction.touch && buttonWaitA)){
			if (Mana >= 10){
				animation.Play("WizardAtk");
				StartCoroutine("buttonwaita");
				Network.Instantiate((GameObject)Resources.Load("ProjectileWizardNormal"), transform.position + transform.forward*1.5f, transform.rotation,0);
				hitWarlock.Play();
				Mana -= 10;
			} else {
				Debug.Log ("Not enough Mana!");
			}
		}
		if(bButtonAction.touch == true && buttonWaitB){
			if (Mana >= 100){
				StartCoroutine("buttonwaitb");
				Network.Instantiate((GameObject)Resources.Load("ProjectileWizardSpecial"), transform.position + transform.forward*7f, transform.rotation,0);
				Mana -= 100;
			} else {
				Debug.Log ("Not enough Mana!");
			}
		}

		if(playerHealth >= 100){
			playerHealth = 100;
		}
		if(playerHealth <= 0){
			playerHealth = 0;
		}
	}
	
/*	public override void SpecialAttackA () 
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
	IEnumerator ReplenishMana(){
		while (replenish){
			yield return new WaitForSeconds(0.5f);
			if (Mana > 100){
				Mana = 100;
			} else {
				Mana += 15;
			}
		}
	}

	IEnumerator Regen(){
		bool regen = true;
		while (regen){
			yield return new WaitForSeconds(2);
			playerHealth += 5;
		}
	}
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

