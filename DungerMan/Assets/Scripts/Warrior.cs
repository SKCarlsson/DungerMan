using UnityEngine;
using System.Collections;

public class Warrior : PlayerScript1 {
	public AudioSource hitWarrior;

	void Start () {
		hitWarrior = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip myHitWarrior;
		myHitWarrior = (AudioClip)Resources.Load ("Sounds/Warrior Sound");
		hitWarrior.clip = myHitWarrior;

		aButtonAction = GameObject.Find ("AButton").GetComponent<AButton> ();
		bButtonAction = GameObject.Find ("BButton").GetComponent<BButton> ();

		//animBool = false;
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
			animation.Play("WarriorAtk");
			//animBool = true;
			StartCoroutine("buttonwaita");
			Instantiate((GameObject)Resources.Load("ProjectileWarriorNormal"), transform.position + transform.forward*3.5f, transform.rotation);
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
				Instantiate((GameObject)Resources.Load("ProjectileWarriorSpecial"), transform.position + transform.forward*4f, transform.rotation);
				Mana -= 75;
			} else {
				Debug.Log ("Not enough rage!");
			}
		}
		//animBool = false;



			


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

