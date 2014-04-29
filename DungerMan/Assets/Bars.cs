using UnityEngine;
using System.Collections;

public class Bars : MonoBehaviour
{
	
	Rect box = new Rect(10, 10, 200, 40);
	Rect rageBox = new Rect(10, 60, 200, 40);
	
	private Texture2D background;
	private Texture2D foreground;
	private Texture2D ragebackground;
	private Texture2D rageforeground;
	
	public float health = 100;
	public int maxHealth = 100;
	public float rage = 100;
	public int maxRage = 100;
	
	void Start()
	{
		
		background = new Texture2D(1, 1, TextureFormat.RGB24, false);
		foreground = new Texture2D(1, 1, TextureFormat.RGB24, false);
		ragebackground = new Texture2D(1,1,TextureFormat.RGB24, false);
		rageforeground = new Texture2D(1,1,TextureFormat.RGB24, false);
		
		background.SetPixel(0, 0, Color.red);
		foreground.SetPixel(0, 0, Color.green);
		ragebackground.SetPixel(0,0,Color.black);
		rageforeground.SetPixel(0,0,Color.red);
		
		background.Apply();
		foreground.Apply();
		ragebackground.Apply();
		rageforeground.Apply();
		maxHealth = 200;
		health = 200;
		maxRage = 100;
		rage = 0;
	}
	
	void Update()
	{
		//health += Input.GetAxisRaw("Horizontal");
		health = this.gameObject.GetComponent<Warrior>().playerHealth;
		rage = this.gameObject.GetComponent<Warrior>().Mana;
		if (health < 0) health = 0;
		if (health > maxHealth) health = maxHealth;

	}
	
	void OnGUI()
	{
		GUI.BeginGroup(box);
		{
			GUI.DrawTexture(new Rect(0, 0, box.width, box.height), background, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 0, box.width*health/maxHealth, box.height), foreground, ScaleMode.StretchToFill);
		}
		GUI.EndGroup(); ;
		GUI.BeginGroup(rageBox);
		{
			GUI.DrawTexture(new Rect(0, 0, rageBox.width, rageBox.height), ragebackground, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 0, rageBox.width*rage/maxRage, box.height), rageforeground, ScaleMode.StretchToFill);
		}
		GUI.EndGroup(); ;
	}
	
}