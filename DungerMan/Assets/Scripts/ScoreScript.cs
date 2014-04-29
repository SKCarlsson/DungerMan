using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public int points = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		print (points);
	
	}

	public void OnGUI(){
		if(GameObject.FindGameObjectsWithTag ("Player").Length >= 1)
		GUI.Box(new Rect(Screen.width/2,Screen.height/8,250,80),"Points: " + points);
		Debug.Log("Points Updated");
	}
}
