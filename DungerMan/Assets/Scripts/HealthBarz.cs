using UnityEngine;
using System.Collections;

public class HealthBarz : MonoBehaviour {
	
	int health;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		health = this.gameObject.GetComponent<PoshScript>().Health;
	}
	
	
	
	void OnGUI(){
		GUI.color = Color.red;
		Vector3 screenPosition = Camera.current.WorldToScreenPoint(transform.position);// gets screen position.
		
		screenPosition.y = Screen.height - (screenPosition.y + 1);// inverts y
		
		Rect rect = new Rect(screenPosition.x - 50, screenPosition.y - 50, 100, 24);// makes a rect centered at the player ( 100x24 )
		Rect healthRect = new Rect(screenPosition.x - 50, screenPosition.y - 50, health, 24);
		
		GUI.Box(healthRect, "");
		GUI.TextField(rect, health + " | 100");
	}
}