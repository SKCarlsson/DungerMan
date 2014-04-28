using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

	public float points = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnGUI()
	{

		GUI.Box(new Rect(Screen.width/2-125,Screen.height/8,250,80),"Points: " + points);

	}
}
