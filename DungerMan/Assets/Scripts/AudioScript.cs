using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {
	public AudioSource hitWarlock;

	// Use this for initialization
	void Start () {
		hitWarlock = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip myHitWarlock;
		myHitWarlock = (AudioClip)Resources.Load ("Sounds/Warlock Sound");
		hitWarlock.clip = myHitWarlock;

	
	}
	
	// Update is called once per frame
	void Update () {
		hitWarlock.Play();
	
	}
}
