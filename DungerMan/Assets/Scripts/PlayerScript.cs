using UnityEngine;
using System.Collections;

public class PlayerScript : Enemy {

	public int pHealth;

	//protected PoshScript cc = GameObject.Find ("Posh(Clone)").GetComponent<PoshScript>();

	public override void ability ()
	{
		Debug.Log ("hello");

	}

	// Use this for initialization
	void Start () {

		pHealth = 200;


	}
	
	// Update is called once per frame
	void Update () {

		print ("player Health: "+ pHealth);
	
	}
}
