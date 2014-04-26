using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Instantiate((GameObject)Resources.Load ("ProjectileWarriorNormal"), new Vector3(5, 1, 5), this.transform.rotation);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
