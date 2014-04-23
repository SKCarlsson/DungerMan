using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour  {
	
	
	
	public static int currTouch = 0;//so other scripts can know what touch is currently on screen
	[HideInInspector]
	public int touch2Watch = 64;
	
	
	void Update ()
	{
		
		// Is there a touch on screen ?
		if (Input.touches.Length <= 0)
		{
			//if no touches execute this code
		}
		else //if there is a touch
		{
			//Loop through all the touches on screen
			for (int i = 0; i < Input.touchCount; i++)
			{
				currTouch = i;
				//Debug.Log(currTouch);
				//executes this code for current touch (i) on screen
				if (this.guiTexture.HitTest (Input.GetTouch (i).position))
				{
					
					//if current touch hits our guitexture, run this code
					if (Input.GetTouch (i).phase == TouchPhase.Began)
					{
						//need to send message because function is not present in script
						this.SendMessage("OnTouchBegan");
						
						
					}
					if (Input.GetTouch (i).phase == TouchPhase.Ended)
					{
						//need to send message because function is not present in script
						this.SendMessage("OnTouchEnded");
						
						
					}
				}
				
			}
		}
		
	}
	
}