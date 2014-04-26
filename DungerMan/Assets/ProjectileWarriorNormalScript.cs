using UnityEngine;
using System.Collections;

public class ProjectileWarriorNormalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("SelfDestruct", 2f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SelfDestruct()
	{
		Destroy(gameObject);
	}

	void OnCollisionEnter(GameObject other)
	{
		Destroy(other);
		Destroy(gameObject);
	}
}
