using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
	
		public int Health;
		public int Damage;
		public int Speed;
		public int AttackRange;
		public int SeeRange;

		public abstract void ability ();



	// Use this for initialization
	void Start () {



	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
