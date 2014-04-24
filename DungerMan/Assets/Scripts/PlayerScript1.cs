using UnityEngine;
using System.Collections;

public abstract class PlayerScript1 : MonoBehaviour {

	public int playerHealth;
	public int Damage;
	protected int Speed;
	protected int AttackRange;
	protected int SeeRange;
	protected int AttackSpeed;
	protected RaycastHit hitinfo;
	protected Enemy cc;
	

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {


	}


	protected void takeDamage()
	{
		
		if (playerHealth <= 0) {
			die();
		}
		
	}

	protected void die()
	{
		Destroy (gameObject);
		
	}


	protected void raycast(){
		Vector3 fwd = this.transform.TransformDirection(Vector3.forward);
		Physics.Raycast (this.transform.position, fwd, out hitinfo, 10);
		if (hitinfo.transform.gameObject!= null) {
			cc = hitinfo.transform.gameObject.GetComponent<Enemy> ();
			enemyTakeDamage ();
				}
		Debug.DrawRay (this.transform.position, fwd,Color.green, 10);
	}

	protected void enemyTakeDamage(){
		cc.Health -=Damage;
		print (cc.Health);
	}



}
