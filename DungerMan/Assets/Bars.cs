using UnityEngine;
using System.Collections;

public class Bars : Warrior
{
	
	Rect box = new Rect(10, 10, 100, 20);
	Rect box2 = new Rect(10, 50, 100, 20);
	
	private Texture2D background;
	private Texture2D foreground;
	private Texture2D background2;
	private Texture2D foreground2;
	
	public float health = 50;
	public int maxHealth = 100;
	public float mana = 50;
	public int maxMana = 100;
	
	void Start()
	{
		
		background = new Texture2D(1, 1, TextureFormat.RGB24, false);
		foreground = new Texture2D(1, 1, TextureFormat.RGB24, false);
		background2 = new Texture2D(1, 1, TextureFormat.RGB24, false);
		foreground2 = new Texture2D(1, 1, TextureFormat.RGB24, false);
		
		background.SetPixel(0, 0, Color.red);
		foreground.SetPixel(0, 0, Color.green);
		background2.SetPixel(0, 0, Color.red);
		foreground2.SetPixel(0, 0, Color.green);
		
		background.Apply();
		foreground.Apply();
		background2.Apply();
		foreground2.Apply();
	}
	
	void Update()
	{
		health += Input.GetAxisRaw("Horizontal");
		if (health < 0) health = 0;
		if (health > maxHealth) health = maxHealth;
		mana += Input.GetAxisRaw("Horizontal");
		if (mana < 0) mana = 0;
		if (mana > maxMana) mana = maxMana;
	}
	
	void OnGUI()
	{
		GUI.BeginGroup(box);
		{
			GUI.DrawTexture(new Rect(0, 0, box.width, box.height), background, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 0, box.width*health/maxHealth, box.height), foreground, ScaleMode.StretchToFill);
		}
		GUI.EndGroup();
		GUI.BeginGroup(box);
		{
			GUI.DrawTexture(new Rect(0, 25, box2.width, box2.height), background2, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 25, box2.width*mana/maxMana, box2.height), foreground2, ScaleMode.StretchToFill);
		}
		GUI.EndGroup();
	}
	
}