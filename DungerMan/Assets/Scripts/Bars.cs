using UnityEngine;
using System.Collections;

public class Bars : MonoBehaviour
{
	// Setting the size and position of the player health and mana bar
	Rect box = new Rect(10, 10, 200, 40);
	Rect box2 = new Rect(10, 60, 200, 40);
	
	//Assigning fore- and background textures.
	private Texture2D background;
	private Texture2D foreground;
	private Texture2D background2;
	private Texture2D foreground2;
	
	// Setting the variables
	public float health = 50;
	public int maxHealth = 200;
	public float mana = 50;
	public int maxMana = 100;
	
	void Start()
	{
		// Giving the textures actual textures
		background = new Texture2D(1, 1, TextureFormat.RGB24, false);
		foreground = new Texture2D(1, 1, TextureFormat.RGB24, false);
		background2 = new Texture2D(1, 1, TextureFormat.RGB24, false);
		foreground2 = new Texture2D(1, 1, TextureFormat.RGB24, false);
		
		//Assigning colors to each texture
		background.SetPixel(0, 0, Color.red);
		foreground.SetPixel(0, 0, Color.green);
		background2.SetPixel(0, 0, Color.black);
		foreground2.SetPixel(0, 0, Color.red);
		
		// Applying our changes and making them visible
		background.Apply();
		foreground.Apply();
		background2.Apply();
		foreground2.Apply();
		
		
	}
	
	void Update()
	{
		//Read variable from the player
		health = this.gameObject.GetComponent<Warrior>().playerHealth;
		mana = this.gameObject.GetComponent<Warrior>().Mana;
	}
	
	void OnGUI()
	{
		GUI.BeginGroup(box);
		{
			// Drawing the visual health bar, combining all of previous made stuff
			GUI.DrawTexture(new Rect(0, 0, box.width, box.height), background, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 0, box.width*health/maxHealth, box.height), foreground, ScaleMode.StretchToFill);
		}
		GUI.EndGroup();
		GUI.BeginGroup(box2);
		{
			// Drawing the visual mana bar, combining all of previous made stuff
			GUI.DrawTexture(new Rect(0, 0, box2.width, box2.height), background2, ScaleMode.StretchToFill);
			GUI.DrawTexture(new Rect(0, 0, box2.width*mana/maxMana, box2.height), foreground2, ScaleMode.StretchToFill);
		}
		GUI.EndGroup();
	}
	
}