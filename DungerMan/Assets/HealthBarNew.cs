using UnityEngine;
using System.Collections;

public class HealthBarNew : MonoBehaviour {

	float health;
	
	float maxHealth;
	
	
	
	float adjustment = 2.3f;
	
	private Vector3 worldPosition = new Vector3();
	
	private Vector3 screenPosition = new Vector3();
	
	private Transform myTransform;
	
	private Camera myCamera ;
	
	private int healthBarHeight = 5;
	
	private int healthBarLeft = 110;
	
	private int barTop = 1;
	
	private GUIStyle myStyle = new GUIStyle();
	
	private GameObject myCam;
	
	
	
	
	void start() 
	{
		
		myCam = GameObject.Find("Camera(Clone)"); //I removed the space from the camera's name in the Unity Inspector, so you will probably need to change this
		
		myTransform = transform;
		
		myCamera = GameObject.Find("Camera(Clone)").GetComponent<Camera>();
		
		health = 50; //arbritrarily chosen values to show that this script works
		
		maxHealth = 100;
		
	}
	
	
	
	void OnGUI()
	{
		
		worldPosition = new Vector3(myTransform.position.x, myTransform.position.y + adjustment,myTransform.position.z);
		screenPosition = myCamera.WorldToScreenPoint(worldPosition);
		
		
		//creating a ray that will travel forward from the camera's position    
		
		Ray ray = new Ray (myCam.transform.position, transform.forward);
		
		RaycastHit hit;
		
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		
		float distance = Vector3.Distance(myCam.transform.position, transform.position); //gets the distance between the camera, and the intended target we want to raycast to
		
		
		
		//if something obstructs our raycast, that is if our characters are no longer 'visible,' dont draw their health on the screen.
		

			
			GUI.color = Color.red;
			
			GUI.HorizontalScrollbar(new Rect (screenPosition.x - healthBarLeft / 2, Screen.height - screenPosition.y - barTop, 100, 0), 0, health, 0, maxHealth); //displays a healthbar
			
			
			
			GUI.color = Color.white;
			
			GUI.contentColor = Color.white;                 
			
			GUI.Label(new Rect(screenPosition.x - healthBarLeft / 2, Screen.height - screenPosition.y - barTop+5, 100, 100), ""+health+"/"+maxHealth); //displays health in text format
			

		
	}
}