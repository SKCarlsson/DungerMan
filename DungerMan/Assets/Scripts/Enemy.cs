using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	
		public int health;
		public int damage;
		public int speed;
		public int attackRange;

		public abstract void ability ();



	// Use this for initialization
	void Start () {



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
