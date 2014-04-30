using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	public AudioSource godlike;
	public AudioSource insane;
	public AudioSource goodJob;
	public AudioSource perfect;
	public AudioSource monsterKill;
	// Initaialize the variable points which is what clients read

	public int points = 0;


	// Use this for initialization
	void Start () {
		godlike = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip Godlike;
		Godlike = (AudioClip)Resources.Load ("Sounds/Godlike");
		godlike.clip = Godlike;

		goodJob = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip GoodJob;
		GoodJob = (AudioClip)Resources.Load ("Sounds/Good Job");
		goodJob.clip = GoodJob;

		insane = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip Insane;
		Insane = (AudioClip)Resources.Load ("Sounds/Insane");
		insane.clip = Insane;

		perfect = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip Perfect;
		Perfect = (AudioClip)Resources.Load ("Sounds/Perfect");
		perfect.clip = Perfect;

		monsterKill = (AudioSource)gameObject.AddComponent("AudioSource");
		AudioClip MonsterKill;
		MonsterKill = (AudioClip)Resources.Load ("Sounds/Monster Kill");
		monsterKill.clip = MonsterKill;
	
	}
	
	// Update is called once per frame
	void Update () {

		print (points);

		if(points >= 20 && points < 50)
			goodJob.Play();
		else if(points >= 50 && points < 100)
			insane.Play();
		else if(points >= 100 && points < 200)
			monsterKill.Play();
		else if(points >= 200 && points < 400)
			perfect.Play();
		else if(points >= 400 && points < 800)
			godlike.Play();

	
	}
	//A function to run another web fucntion, this form allows external functions to run net functions in this script

	public void addPoint(int enemyPoint){
		networkView.RPC ("net_addPoints", RPCMode.All, enemyPoint);
	}
	//The net functions that adds a point to all the players screens
	[RPC]
	public void net_addPoints(int enemyPoint){
		points += enemyPoint;
	}
	// The gui that shows the current points
	public void OnGUI(){
		if(GameObject.FindGameObjectsWithTag ("Player").Length >= 1)
		GUI.Box(new Rect(Screen.width/2,Screen.height/8,250,80),"Points: " + points);
		Debug.Log("Points Updated");
	}
}
