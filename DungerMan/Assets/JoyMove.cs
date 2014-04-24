﻿using UnityEngine;
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
	private float C = 0;
	private float A = 0; 

	private float rotation=0;

	void Start()
	{

		CPos = transform.position; 
		basePos = transform.position; 

		basePos.y = 0;
		basePos.x = 0;
		basePos.z = 0;

		joystick = GameObject.Find("joystick").GetComponent<Joystick>();


	}

	void Update () {


		CPos.z = 0;
		CPos.y = 1;
		CPos.x = 0;
		// tried to make the rotation by using sine:
		/*
		c = Vector3.Distance(basePos, joystick.position);
		a = Vector3.Distance(CPos, joystick.position);
		A = Mathf.Asin (a / c);
		C = Mathf.Asin((Mathf.Sin((A)*c)/a));*/


		if (joystick.tapCount == 1) {
			rotation =Vector3.Angle(joystick.position, CPos);

			if (joystick.position.x < 0) {
				rotation = 360 - rotation;
					}

			this.transform.rotation = Quaternion.AngleAxis (rotation, Vector3.up);
			}


		//print (Vector3.Angle (joystick.position, CPos));

		

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
		if (joystick.position.x == 0 && joystick.position.y == 0) {

			rigidbody.velocity = new Vector3(0, 0, 0);
				}

	}
}