using UnityEngine;
using System.Collections;

public class Joystick : TouchButtonLogic {
	
	
	public Transform player = null;
	public float playerSpeed = 2.0f;
	public float maxJoyDelta = 0.05f;
	private Vector3 oJoyPos; // Original position of joystick
	private Vector3 joyDelta; // Maximum position of joystick
	private Transform joyTrans = null; // to move the joystick
	public CharacterController troller;
	
	
	void Start () 
	{
		
		joyTrans = this.transform;
		oJoyPos = joyTrans.position;
		
		
	}
	
	void OnTouchBegan ()
	{
		//need to cache the touch index that started the joystick
		touch2Watch = TouchButtonLogic.currTouch;
		
	}
	
	void OnTouchMovedAnywhere ()
	{
		if (TouchButtonLogic.currTouch == touch2Watch) 
		{
			
			//move the joystick
			joyTrans.position = MoveJoyStick ();
			ApplyJoyDelta ();
			
		}
	}
	
	void OnTouchStayedAnywhere ()
	{
		if (TouchButtonLogic.currTouch == touch2Watch) 
		{
			
			ApplyJoyDelta ();
			
		}
	}
	void OnTouchEndedAnywhere ()
	{
		if (TouchButtonLogic.currTouch == touch2Watch) 
		{
			
			//move the joystick back to its origin position
			joyTrans.position = oJoyPos;
			touch2Watch = 64;
			
		}
	}
	
	void ApplyJoyDelta ()
	{
		troller.Move ((player.forward * joyDelta.y + player.right * joyDelta.x) * playerSpeed * Time.deltaTime);
	}
	
	Vector3 MoveJoyStick() //This limits the positioning of the joystick
	{
		float x = Input.GetTouch (touch2Watch).position.x / Screen.width;
		float y = Input.GetTouch (touch2Watch).position.y / Screen.height;
		
		Vector3 position = new Vector3 (Mathf.Clamp(x, oJoyPos.x - maxJoyDelta, oJoyPos.x + maxJoyDelta),
		                                Mathf.Clamp(y, oJoyPos.y - maxJoyDelta, oJoyPos.y + maxJoyDelta), 0);
		
		//connecting the joystick with the player, making him move through the joystick
		joyDelta = new Vector3 (position.x - oJoyPos.x, position.y - oJoyPos.y, 0).normalized;
		
		return position;
	}
	
}