using UnityEngine;
using System.Collections;

public class JoyMove : MonoBehaviour {

	// Use this for initialization
	private PlayerScript1 ps;
	public Joystick joystick;
	public float speed = 10;
	public bool useAxisInput = true;
	private float h = 0;
	private float v = 0;

	Vector3 CPos;
	
	private float rotation=0;

	void Start()
	{
		// does so it is only the player with the phone who can control this:
		if(!networkView.isMine)
			return;

		CPos = transform.position; 
		joystick = GameObject.Find("joystick").GetComponent<Joystick>();


	}

	void Update () {

		// Cpos is used to make a startingpoint for creating the angle
		CPos.z = 0;
		CPos.y = 1;
		CPos.x = 0;


		if (joystick.tapCount == 1) {
			rotation =Vector3.Angle(joystick.position, CPos);

			if (joystick.position.x < 0) {
				rotation = 360 - rotation;
					}
			// uses the angle of the joystick to turn the player
			this.transform.rotation = Quaternion.AngleAxis (rotation, Vector3.up);
			}


		if(!useAxisInput) {
			// assigns the position of the joystick to h and v
			h = joystick.position.x;
			v = joystick.position.y;
		}
		else {
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");
		}

		// uses the position of the joystick to move the player:  
		if(Mathf.Abs(h) > 0) {
			rigidbody.velocity = new Vector3(h * speed, 0, rigidbody.velocity.y);
		}
		if(Mathf.Abs(v) > 0) {
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, v * speed);
		}
		if (joystick.position.x == 0 && joystick.position.y == 0) {

			rigidbody.velocity = new Vector3(0, 0, 0);
				}

	}
}
