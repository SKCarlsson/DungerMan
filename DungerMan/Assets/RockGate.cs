using UnityEngine;
using System.Collections;

public class RockGate : MonoBehaviour {
	ParticleSystem particle;
	// Use this for initialization
	void Start () {
		particle = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
		particle.playOnAwake = false;
		particle.Stop();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp("f"))
		{
			Explosion();
		}

	}

	void Explosion()
	{
		particle.Play();
		print ("big balls");
		Invoke("SelfDestroy", 4f);
	}

	void SelfDestroy()
	{
		Destroy(gameObject);
	}
}
