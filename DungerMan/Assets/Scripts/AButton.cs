using UnityEngine;
using System.Collections;

public class AButton : TouchLogic {



	void OnTouchBegan () 
	{
		Debug.Log ("The touch has begun " + this.name);

	}

	void OnTouchEnded () 
	{
		Debug.Log ("The touch has ended " + this.name);
		
	}
}
