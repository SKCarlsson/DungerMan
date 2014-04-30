using UnityEngine;
using System.Collections;

public class HealthBarz : MonoBehaviour {
	// Instantiating a health variable
	int health;
	
	
	
	
	// Update is called once per frame
	void Update () {
		//Connecting the variable with the enemy
		health = this.gameObject.GetComponent<PoshScript>().Health;
	}
	
	
	
	void OnGUI(){
		//Setting the color of the health bar
		GUI.color = Color.red;
		// Getting the position of the enemy to place the bar later on
		Vector3 screenPosition = Camera.current.WorldToScreenPoint(transform.position);// gets screen position.
		
		screenPosition.y = Screen.height - (screenPosition.y + 1);// inverts y
		
		Rect rect = new Rect(screenPosition.x - 50, screenPosition.y - 50, 100, 24);// makes a rect centered at the player ( 100x24 )
		Rect healthRect = new Rect(screenPosition.x - 50, screenPosition.y - 50, health, 24);
		
		//Creating the two boxes, first the depleating box, and second the text with how much health has been lost
		GUI.Box(healthRect, "");
		GUI.TextField(rect, health + " | 100");
	}
}