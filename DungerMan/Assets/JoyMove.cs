using UnityEngine;
using System.Collections;

public class JoyMove : MonoBehaviour {

	// Use this for initialization
	public Joystick joystick;
	public float speed = 10;
	public bool useAxisInput = true;
	private float h = 0;
	private float v = 0;


	void Update () {
	
		if(!useAxisInput) {
			h = joystick.position.x;
			v = joystick.position.y;
		}
		else {
			h = Input.GetAxis("Horizontal");
			v = Input.GetAxis("Vertical");
		}
		if(Mathf.Abs(h) > 0) {
			rigidbody.velocity = new Vector3(h * speed, 0, rigidbody.velocity.y);
		}
		if(Mathf.Abs(v) > 0) {
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, v * speed);
		}

	}
}
