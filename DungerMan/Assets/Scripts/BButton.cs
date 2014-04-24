using UnityEngine;
using System.Collections;

public class BButton : TouchLogic {

	public bool touch = false;
	
	void OnTouchBegan () 
	{
		Debug.Log ("The touch has begun " + this.name);
		touch = true;
		//Debug.Log ("the boolean is " + touch);
	}
	
	void OnTouchEnded () 
	{
		Debug.Log ("The touch has ended " + this.name);
		touch = false;
		//Debug.Log ("the boolean is " + touch);
		
	}
}
