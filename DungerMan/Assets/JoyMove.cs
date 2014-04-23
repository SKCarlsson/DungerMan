using UnityEngine;
using System.Collections;

public class JoyMove : MonoBehaviour {

	// Use this for initialization
	public Joystick joystick;
	public float speed = 10;
	public bool useAxisInput = true;
	private float h = 0;
	private float v = 0;

	Vector3 CPos;
	Vector3 basePos;

	// for the sine
	private float c = 0;
	private float a = 0;

	void Start()
	{
		CPos = transform.position; 
		basePos = transform.position; 

		basePos.y = 0;
		basePos.x = 0;

		joystick = GameObject.Find("joystick").GetComponent<Joystick>();


	}

	void Update () {

		CPos.y = 0;
		CPos.x = joystick.position.x;

		c = Vector3.Distance(basePos, joystick.transform.position);
		a = Vector3.Distance(CPos, joystick.transform.position);

		print(Mathf.Asin (a / c));

		//print("x: "+joystick.position.x);
		//print("y: "+joystick.position.y);
		

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
