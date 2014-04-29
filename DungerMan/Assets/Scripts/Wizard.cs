using UnityEngine;
using System.Collections;

public class Wizard : PlayerScript1 {
	public AudioSource hitWarlock;
	bool replenish = true;
	void Start () {
		hitWarlock = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip myHitWarlock;
		myHitWarlock = (AudioClip)Resources.Load ("Sounds/Warlock Sound");
		hitWarlock.clip = myHitWarlock;
		
		aButtonAction = GameObject.Find ("AButton").GetComponent<AButton> ();
		bButtonAction = GameObject.Find ("BButton").GetComponent<BButton> ();
		
		
		Damage = 25;
		playerHealth = 100;
		
		//Energy - Rage
		Mana = 0;
		StartCoroutine("ReplenishMana");

		//Regen
		StartCoroutine("Regen");
	}
	
	// Update is called once per frame
	void Update () {
		
		print ("You have "+Mana+" Mana.");
		
		//print (aButtonAction.touch);
		//print (aButtonAction.touch);
		
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
	
	IEnumerator buttonwaita(){
		buttonWaitA = false;
		yield return new WaitForSeconds(0.25f);
		buttonWaitA = true;
	}
	
	
	IEnumerator buttonwaitb(){
		buttonWaitB = false;
		yield return new WaitForSeconds(5);
		buttonWaitB = true;
	}
	
	
	
}

