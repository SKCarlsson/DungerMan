using UnityEngine;
using System.Collections;

public class TouchButtonTalk : TouchButtonLogic

{
	void OnTouchBegan ()
	{
		Debug.Log ("The Touch has begun on " + this.name);
	}

	void OnTouchEnded ()
	{
		Debug.Log ("The Touch has ended on " + this.name);
	}

}
