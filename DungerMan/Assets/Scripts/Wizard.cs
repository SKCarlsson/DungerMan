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
				Instantiate((GameObject)Resources.Load("ProjectileWizardNormal"), transform.position + transform.forward*1.5f, transform.rotation);
				hitWarlock.Play();
				Mana -= 10;
			} else {
				Debug.Log ("Not enough Mana!");
			}
		}
		if(bButtonAction.touch == true && buttonWaitB){
			if (Mana >= 100){
				StartCoroutine("buttonwaitb");
				Instantiate((GameObject)Resources.Load("ProjectileWizardSpecial"), transform.position + transform.forward*7f, transform.rotation);
				Mana -= 100;
			} else {
				Debug.Log ("Not enough Mana!");
			}
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
				Mana += 5;
			}
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

